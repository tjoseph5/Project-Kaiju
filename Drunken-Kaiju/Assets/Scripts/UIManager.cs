using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager singleton;

    [HideInInspector] public GameObject startGameUI;
    [HideInInspector] public GameObject inGameUI;
    [HideInInspector] public GameObject endGameUI;

    [SerializeField] [Range(0,2)] int uiStatus;

    [SerializeField] Slider pukeDisplay;
    GameObject chainMultiplierDisplay;
    [SerializeField] TMPro.TextMeshProUGUI scoreDisplayText;
    [SerializeField] TMPro.TextMeshProUGUI tempCRMDisplay;
    [SerializeField] Slider tempCRSlider;
    [SerializeField] GameObject buildingHealthUI;
    [SerializeField] Slider buildingHealthSlider;

    public TMPro.TextMeshProUGUI timerText;

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

        //uiStatus = 2;
        chainMultiplierDisplay = GameObject.Find("Chain Multiplier");
    }

    // Update is called once per frame
    void Update()
    {
        pukeDisplay.value = KaijuMovement.singleton.pukeAmount;
        scoreDisplayText.text = ScoreManager.singleton.standardScore.ToString();
        tempCRMDisplay.text = ScoreManager.singleton.tempCRMultiplier.ToString();
        tempCRSlider.value = ScoreManager.singleton.tempCRScoreTimer;

        if (KaijuMovement.singleton.building != null)
        {
            buildingHealthUI.SetActive(true);
            buildingHealthSlider.value = KaijuMovement.singleton.building.health;
        }
        else
        {
            buildingHealthUI.SetActive(false);
        }

        timerText.text = Timer.singleton.fullTimer;

        if (ScoreManager.singleton.tempCRMultiplier <= 1)
        {
            chainMultiplierDisplay.SetActive(false);
        }
        else if (ScoreManager.singleton.tempCRMultiplier > 1)
        {
            chainMultiplierDisplay.SetActive(true);
        }

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
