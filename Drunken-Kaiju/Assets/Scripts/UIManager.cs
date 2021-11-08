using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager singleton;

    [HideInInspector] public GameObject startGameUI;
    [HideInInspector] public GameObject inGameUI;
    [HideInInspector] public GameObject endGameUI;

    [SerializeField] [Range(0,2)] int uiStatus;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        startGameUI = gameObject.transform.GetChild(0).gameObject;
        inGameUI = gameObject.transform.GetChild(1).gameObject;
        endGameUI = gameObject.transform.GetChild(2).gameObject;

        uiStatus = 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch (uiStatus)
        {
            case 0:
                startGameUI.SetActive(true);
                inGameUI.SetActive(false);
                endGameUI.SetActive(false);
                break;

            case 1:
                startGameUI.SetActive(false);
                inGameUI.SetActive(true);
                endGameUI.SetActive(false);
                break;

            case 2:
                startGameUI.SetActive(false);
                inGameUI.SetActive(false);
                endGameUI.SetActive(true);
                break;
        }

        if(!Timer.singleton.timeStart && !Timer.singleton.gameOver)
        {
            uiStatus = 0;
        }
        else if (Timer.singleton.timeStart)
        {
            uiStatus = 1;
        }
        else if (Timer.singleton.gameOver)
        {
            uiStatus = 2;
        }
    }
}
