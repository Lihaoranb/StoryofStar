using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private string lastkey = "";
    public float maxAwaitTime;
    public float lastPressTime;
    public float moveX;
    public float moveY;
    public bool A;
    public bool isKeying;
    Vector2 target;
    public Vector2 GetMovementDir()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(moveX, moveY);
        dir = dir.normalized;
        return dir;
    }

    public void CheckIsRunning()
    {
        string currentKey = "";
        if (Input.GetKeyDown(KeyCode.W)) currentKey = "W";
        if (Input.GetKeyDown(KeyCode.S)) currentKey = "S";
        if (Input.GetKeyDown(KeyCode.A)) currentKey = "A";
        if (Input.GetKeyDown(KeyCode.D)) currentKey = "D";
        
        if (currentKey != "")
        {
            if (currentKey == lastkey && (Time.time - lastPressTime) < maxAwaitTime)
            {
                A = true;
            }
            else A = false;
            lastkey = currentKey;
            lastPressTime = Time.time;
        }
    }

     
    
}
