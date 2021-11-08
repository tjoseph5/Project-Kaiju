using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer singleton;

    [Range(0,59)] public float seconds = 59.99f;
    public int minutes = 2;

    public string fullTimer;
    public bool gameOver;
    public bool timeStart;


    void Awake()
    {
        singleton = this;
    }


    void Start()
    {
        
    }


    void Update()
    {
        if(seconds > 10 && seconds < 59)
        {
            fullTimer = "0" + minutes + " : " + seconds.ToString("F0");
        }
        else if(seconds <= 9)
        {
            fullTimer = "0" + minutes + " : " + "0" + seconds.ToString("F0");
        }
        else if (seconds > 59)
        {
            fullTimer = "0" + minutes + " : "  + "00";
        }




        if (timeStart)
        {
            seconds -= Time.deltaTime;
            gameOver = false;
        }

        if (seconds <= 0 && minutes > 0)
        {
            seconds = 59.99f;
            minutes -= 1;
        } 
        else if(seconds <= 0 && minutes == 0)
        {
            gameOver = true;
        }

        if(gameOver == true)
        {
            seconds = 0;
            minutes = 0;
            timeStart = false;
            KaijuMovement.singleton.OnDisable();
        }
    }
}
