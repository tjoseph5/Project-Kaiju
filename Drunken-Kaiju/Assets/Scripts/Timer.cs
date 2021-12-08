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
    public bool rankFinished;

    public string fullMusicTimer;

    [HideInInspector] public AudioSource musicPlayer;

    void Awake()
    {
        singleton = this;
    }


    void Start()
    {
        rankFinished = false;
        musicPlayer = transform.GetChild(0).gameObject.GetComponent<AudioSource>();
    }


    void Update()
    {
        fullMusicTimer = ((int)musicPlayer.time).ToString();

        if(seconds > 10 && seconds < 59)
        {
            fullTimer = "0" + minutes + ":" + seconds.ToString("F0");
        }
        else if(seconds <= 9)
        {
            fullTimer = "0" + minutes + ":" + "0" + seconds.ToString("F0");
        }
        else if (seconds > 59 && minutes != 0)
        {
            fullTimer = "0" + (minutes + 1) + ":"  + "00";
        }
        else if (seconds > 59 && minutes == 0)
        {
            fullTimer = "01" + ":" + "00";
        }

        if(minutes == 0)
        {
            UIManager.singleton.timerText.color = Color.red;
        }


        if (timeStart)
        {
            seconds -= Time.deltaTime;
            gameOver = false;

            KaijuMovement.singleton.OnEnable();
        }
        else
        {
            KaijuMovement.singleton.OnDisable();
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

        if(GameObject.Find("Game Manager"))
        {
            if (timeStart || !timeStart && !gameOver && !rankFinished)
            {
                Menu.singleton.menuStates = Menu.MenuStates.inGame;
            }
            else if (gameOver)
            {
                Menu.singleton.menuStates = Menu.MenuStates.endGame;
            }
        } 
    }
}
