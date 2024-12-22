
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField]public GameInput gameInput;
    Rigidbody2D rb;
   
    public float walkSpeed;
    public float runSpeed;
     bool  isMove;

    Animator ani;
    private float faceX;
    private float faceY;
    Vector2 direction;
    private int mCurrentIndex;   

    private List<Vector3> mPathPointList;
    bool isRun;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        direction = gameInput.GetMovementDir();
      gameInput.CheckIsRunning();
            PlayerMove();
            PlayAni();
      
    }
    
    void PlayerMove()
    {

        if (direction != Vector2.zero)
        {
            if (!gameInput.A)
            {
                rb.velocity = new Vector2 (direction.x, direction.y)*walkSpeed;
            }
            else
            {
                rb.velocity = new Vector2(direction.x, direction.y) * runSpeed;
            }
        }
        else 
        {
            rb.velocity = direction*0f;
        }
    }
    void PlayAni()
    {

        if (direction != Vector2.zero)
        {
            if (!gameInput.A)
            {
                ani.SetBool("Is Walking", true);
                ani.SetBool("Is Running", false);
                faceX = gameInput.moveX;
                faceY = gameInput.moveY;
            }
            else
            {
                ani.SetBool("Is Walking", false);
                ani.SetBool("Is Running", true);
                faceX = gameInput.moveX;
                faceY = gameInput.moveY;
            }

        }
        else 
        {
            ani.SetBool("Is Walking", false);
            ani.SetBool("Is Running", false);
        }
        ani.SetFloat("X", faceX);
        ani.SetFloat("Y", faceY);
    }
    private void Move()
    {
        if (mPathPointList == null || mPathPointList.Count <= 0)
            return;

        if (Vector2.Distance(transform.position, mPathPointList[mCurrentIndex]) > 0.2f)
        {
            Vector3 dir = (mPathPointList[mCurrentIndex] - transform.position).normalized;
            if (isRun)
            {
                transform.position += Time.deltaTime * 1.8f * dir;
            }
            else
            {
                transform.position += Time.deltaTime * 3f * dir;
            }

        }
        else
        {
            if (mCurrentIndex == mPathPointList.Count - 1)
            {
                return;
            }
            mCurrentIndex++;
        }
    }
    //private void CreatePath(Vector2 target)
    //{
    //    mCurrentIndex = 0;

    //    seeker.StartPath(transform.position, target, path =>
    //    {
    //        mPathPointList = path.vectorPath;
    //    });
    //}

    private void CheckMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if ((Time.time - gameInput.lastPressTime) < gameInput.maxAwaitTime)
            {
                isRun = true;
            }
            else
            {
                isRun = false;
            }
            gameInput.lastPressTime = Time.time;

           // CreatePath(mousePos);
        }
    }

}

