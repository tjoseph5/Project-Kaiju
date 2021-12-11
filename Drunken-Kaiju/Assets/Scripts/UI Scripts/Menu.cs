using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //THIS SCRIPT SHOULD BE WORKED UPON AND SHOULD BE ONLY FOR DETECTING WHICH SCENE THE GAME IS IN, PAUSING AND UNPAUSING, AND LOADING/STARTING AND QUITTING THE GAME

    public static Menu singleton;

    [Header("Control Setup")]
    public InputActionReference select;
    public InputActionReference startButton;
    public InputActionReference exitPause;
    public InputActionReference navigate;

    Scene scene;

    int sceneID;

    public Animator pauseAnimator;

    public enum MenuStates { mainMenu, howToPlay, inGame, endGame}
    public MenuStates menuStates = MenuStates.mainMenu;

    bool howToPlay;

    void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        sceneID = scene.buildIndex;

        if(sceneID == 0)
        {
            pauseAnimator = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (sceneID)
        {
            case 0:
                if (select.action.triggered)
                {
                    select.action.Disable();

                    LevelLoader.loader.LoadLevel(1);
                }
                break;

            case 1:

                

                if (startButton.action.triggered)
                {
                    if (Timer.singleton.timeStart)
                    {
                        pauseAnimator.SetTrigger("Pause");
                        Pause();
                    }
                    else if (!Timer.singleton.timeStart)
                    {
                        pauseAnimator.SetTrigger("Pause");
                    }

                    if (Timer.singleton.rankFinished)
                    {
                        SceneManager.LoadScene(0);
                    }
                }

                if (exitPause.action.triggered && !Timer.singleton.timeStart)
                {
                    pauseAnimator.SetTrigger("Pause");
                }

                break;
        }

        if (!GameObject.Find("Game Manager"))
        {
            if (!howToPlay)
            {
                menuStates = MenuStates.mainMenu;
            }
            else
            {
                menuStates = MenuStates.howToPlay;
            }
            
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
        exitPause.action.Enable();
        navigate.action.Enable();
    }

    private void OnDisable()
    {
        select.action.Disable();
        startButton.action.Disable();
        exitPause.action.Disable();
        navigate.action.Disable();
    }
    #endregion
}
