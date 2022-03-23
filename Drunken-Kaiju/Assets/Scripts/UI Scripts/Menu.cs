using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //THIS SCRIPT SHOULD BE WORKED UPON AND SHOULD BE ONLY FOR DETECTING WHICH SCENE THE GAME IS IN, PAUSING AND UNPAUSING, AND LOADING/STARTING AND QUITTING THE GAME

    public static Menu singleton;

    [Header("Base Control Setup")]
    public InputActionReference select;
    public InputActionReference startButton;

    [Header("Navigate Control Setup")]
    public InputActionReference navigateL;
    public InputActionReference navigateR;
    public InputActionReference navigateU;
    public InputActionReference navigateD;

    [Header("Scene Management")]
    Scene scene;

    public int sceneID;

    public Animator pauseAnimator;

    public enum MenuStates { mainMenu, howToPlay, inGame, endGame}
    public MenuStates menuStates = MenuStates.mainMenu;
    public bool titleStarted;

    AudioSource audioSource;

    void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        sceneID = scene.buildIndex;

        titleStarted = false;

        audioSource = gameObject.GetComponent<AudioSource>();

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (sceneID == 0)
        {
            if (MenuSelectUI.singleton.enabled)
            {
                if (Menu.singleton.select.action.triggered || Menu.singleton.startButton.action.triggered)
                {
                    audioSource.volume = 0.4f;
                    audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                }
            }
        }
        else if (sceneID == 1)
        {
            if (MenuSelectUI.singleton.enabled || MenuSelectUIEnd.singleton.enabled)
            {
                if (Menu.singleton.select.action.triggered || Menu.singleton.startButton.action.triggered)
                {
                    audioSource.volume = 0.4f;
                    audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                }
            }

            if (!Timer.singleton.timeStart)
            {
                startButton.action.Disable();
            }
            else
            {
                startButton.action.Enable();
            }
        }
        

        switch (sceneID)
        {
            case 0:
                if (startButton.action.triggered && !titleStarted)
                {
                    if (pauseAnimator.GetCurrentAnimatorStateInfo(0).IsName("Play Glowing"))
                    {
                        startButton.action.Disable();
                        titleStarted = true;
                        Debug.Log("entering menu");

                        audioSource.volume = 0.4f;
                        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                        startButton.action.Disable();
                    }

                    pauseAnimator.SetTrigger("next");
                }

                if(select.action.triggered || startButton.action.triggered)
                {
                    if(menuStates == MenuStates.howToPlay && pauseAnimator.GetCurrentAnimatorStateInfo(0).IsName("How To Play") || menuStates == MenuStates.howToPlay && pauseAnimator.GetCurrentAnimatorStateInfo(0).IsName("Credits"))
                    {
                        pauseAnimator.SetTrigger("next");
                        menuStates = MenuStates.mainMenu;

                        audioSource.volume = 0.4f;
                        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                    }
                }
                break;

            case 1:

                

                if (startButton.action.triggered)
                {
                    if (Timer.singleton.timeStart)
                    {
                        pauseAnimator.SetTrigger("Pause");
                        Pause();

                        audioSource.volume = 0.4f;
                        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                    }
                    else if (!Timer.singleton.gameOver && !Timer.singleton.timeStart && !Timer.singleton.rankFinished)
                    {
                        pauseAnimator.SetTrigger("Pause");

                        audioSource.volume = 0.4f;
                        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                    }
                }

                if (startButton.action.triggered && !Timer.singleton.timeStart)
                {
                    pauseAnimator.SetTrigger("Pause");

                    audioSource.volume = 0.4f;
                    audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                }

                if (select.action.triggered || startButton.action.triggered)
                {
                    if (menuStates == MenuStates.howToPlay && pauseAnimator.GetCurrentAnimatorStateInfo(0).IsName("How To Play"))
                    {
                        pauseAnimator.SetTrigger("next");
                        menuStates = MenuStates.inGame;

                        audioSource.volume = 0.4f;
                        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[5]);
                    }
                }

                if(pauseAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Time.timeScale == 0f && !Timer.singleton.timeStart)
                {
                    Debug.Log("Glitch happened: " + Time.timeScale + "Time Start is: " + Timer.singleton.timeStart);
                    
                    //Resume();
          
                }

                break;
        }
    }

    public void Resume()
    {
        Timer.singleton.timeStart = true;
        Timer.singleton.musicPlayer.UnPause();
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Timer.singleton.timeStart = false;
        Timer.singleton.musicPlayer.Pause();
        Time.timeScale = 0f;
    }

    #region OnEnable / OnDisable
    private void OnEnable()
    {
        select.action.Enable();
        startButton.action.Enable();

        navigateL.action.Enable();
        navigateR.action.Enable();
        navigateU.action.Enable();
        navigateD.action.Enable();
    }

    private void OnDisable()
    {
        select.action.Disable();
        startButton.action.Disable();

        navigateL.action.Disable();
        navigateR.action.Disable();
        navigateU.action.Disable();
        navigateD.action.Disable();
    }
    #endregion
}
