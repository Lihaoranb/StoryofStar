
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEditor.PlayerSettings;

public class player : MonoBehaviour
{
    private float faceX;
    private float faceY;
    float X; float Y;
    float currentspeed;
    public float Walkspeed=1.8f;
    public float Runspeed=3.5f;


    public Transform tempTarget;
    Animator ani;
    Rigidbody2D rb;
    Vector2 movement;
    Vector3 targetPos;
    private Vector3 lastTapPos;
    private float lastTapTime = -1f;
    private float doubleTapTime = 0.3F;
    public static player instance;
    bool isUsing;
    // Start is called before the first frame update
    void Start()
    {
       
        //destinationSetter = GetComponent<AIDestinationSetter>();
        //aipath = GetComponent<AIPath>();
        //aipath.canMove = false;
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentspeed = Walkspeed;
        //aipath.maxSpeed = Walkspeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isUsing)
        {
            UpdateAnimation(targetPos);
        }
        
        if (Input.GetAxis("Horizontal")!=0||Input.GetAxis("Vertical")!=0)
        {
            isUsing = false;
            //aipath.canMove = false;
            //ClearTarget();
            MoveWithKey();
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    isUsing = true;
        //    targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //    targetPos.z = transform.position.z;

        //    if (Time.time - lastTapTime <= doubleTapTime&&Vector3.Distance(targetPos,lastTapPos)<1f)
        //    {
        //        aipath.maxSpeed = Runspeed;
        //        currentspeed = Runspeed;
        //    }
        //    else
        //    {
        //        aipath.maxSpeed = Walkspeed;
        //        currentspeed = Walkspeed;
        //    }

        //    lastTapTime = Time.time;
        //    lastTapPos = targetPos;

        //    aipath.canMove = true ;

        //    ClearTarget();

           
        //    GameObject newTarget = new GameObject("Target");
        //    newTarget.transform.position = targetPos;
        //    tempTarget=newTarget.transform;
        //    destinationSetter.target = tempTarget.transform;


            
        //}
        
        //if (isUsingPathfinding && aipath.reachedDestination)
        //{
        //    aipath.canMove=false;
        //    ClearTarget();

        //}
    
    } 

    void MoveWithKey()
    {
        currentspeed = Input.GetKey(KeyCode.LeftShift) ? Runspeed : Walkspeed;
        X = Input.GetAxisRaw("Horizontal");
        Y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(X,Y).normalized;
        rb.velocity = movement*currentspeed;
        playerani(movement);
    }
    //void ClearTarget()
    //{
    //    if (tempTarget!=null)
    //    {
    //        Destroy(tempTarget.gameObject);
    //        tempTarget = null;
    //        destinationSetter.target=null;
    //    }
    //}
    void playerani(Vector2 pos)
    {
        if (pos != Vector2.zero)
        {
            if (currentspeed<3)
            {
                ani.SetBool("Is Walking", true);
                ani.SetBool("Is Running", false);
                faceX = X;
                faceY = Y;
            }
            else
            {
                ani.SetBool("Is Walking", false);
                ani.SetBool("Is Running", true);
                faceX = X;
                faceY = Y;
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

    void UpdateAnimation(Vector3 pos)
    {
        float dirX; float dirY;

        Vector2 dir = (pos-transform.position);

        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            dirX = Mathf.Sign(dir.x);
            dirY = 0;
        }
        else
        {
            dirX = 0;
            dirY = Mathf.Sign(dir.y);
        }

        
        if (dir.magnitude>0.5f)
        {
            if (currentspeed < 3)
            {
                ani.SetBool("Is Walking", true);
                ani.SetBool("Is Running", false);
                faceX = dirX;
                faceY = dirY;
            }
            else
            {
                ani.SetBool("Is Walking", false);
                ani.SetBool("Is Running", true);
                faceX = dirX;
                faceY = dirY;

            }
            ani.SetFloat("X", faceX);
            ani.SetFloat("Y", faceY);
        }
        else 
        {
            ani.SetBool("Is Walking", false);
            ani.SetBool("Is Running", false);
            ani.SetFloat("X", faceX);
            ani.SetFloat("Y", faceY);
        }
            
        
    }
}
