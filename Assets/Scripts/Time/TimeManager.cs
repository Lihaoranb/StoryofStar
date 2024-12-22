using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int gameSecond, gameMinute,gameHour,gameDay;
    public bool gameClockPause;
    private float tikTime;
    private void Update()
    {
        if (!gameClockPause)
        {
           
            tikTime = Time.deltaTime;
            if (tikTime>=Settings.secondHold)
            {
                tikTime-=Settings.secondHold;
                UpdateGameTime();
            }
        }
    }
    private void NewGame()
    {
        gameSecond = 0;
        gameMinute = 0; 
        gameHour = 20;
        gameDay = 1;
    }
    private void UpdateGameTime()
    {
        gameSecond++;
        if (gameSecond>Settings.minuteHold)
        {
            gameMinute++;
            gameSecond = 0;

            if (gameMinute > Settings.minuteHold)
            {
                gameHour++;
                gameMinute = 0;
                if (gameHour > Settings.hourHold)
                {
                    gameDay++;
                    gameHour = 0;
                    if (gameDay > Settings.dayHold)
                    {

                    }
                }
            }
        }
    }
}
