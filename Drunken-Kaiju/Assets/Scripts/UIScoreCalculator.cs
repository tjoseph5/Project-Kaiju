using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIScoreCalculator : MonoBehaviour
{

    Animator eGAnimator;
    public Text text;
    int numberDisplay;

    bool pass;

    [SerializeField] enum ScoreType { baseScore, specialScore, chainScore, finalScore};
    [SerializeField] ScoreType scoreType = ScoreType.baseScore;


    void Start()
    {
        eGAnimator = UIManager.singleton.endGameUI.GetComponent<Animator>();
        //gameObject.GetComponent<Text>().text = text.text;

        switch (scoreType)
        {
            case ScoreType.baseScore:
                numberDisplay = ScoreManager.singleton.standardScore * 2;
                break;

            case ScoreType.specialScore:
                numberDisplay = ScoreManager.singleton.specialBuildingMultiplier * 2;
                break;

            case ScoreType.chainScore:
                numberDisplay = ScoreManager.singleton.chainReactionMultiplier * 2;
                break;

            case ScoreType.finalScore:
                numberDisplay = ScoreManager.singleton.totalScore * 2;
                break;
        }
    }


    void Update()
    {
        if (Timer.singleton.gameOver)
        {
            text.text = numberDisplay.ToString();

            switch (scoreType)
            {
                case ScoreType.baseScore:
                    if (numberDisplay > ScoreManager.singleton.standardScore)
                    {
                        numberDisplay -= ScoreManager.singleton.standardScore / 100;
                    }
                    else if (numberDisplay <= ScoreManager.singleton.standardScore)
                    {
                        numberDisplay = ScoreManager.singleton.standardScore;
                        this.pass = true;
                    }
                    break;

                case ScoreType.specialScore:
                    if (numberDisplay > ScoreManager.singleton.specialBuildingMultiplier)
                    {
                        numberDisplay -= 1;
                    }
                    else if (numberDisplay <= ScoreManager.singleton.specialBuildingMultiplier)
                    {
                        numberDisplay = ScoreManager.singleton.specialBuildingMultiplier;
                        this.pass = true;
                    }
                    break;

                case ScoreType.chainScore:
                    if (numberDisplay > ScoreManager.singleton.chainReactionMultiplier)
                    {
                        numberDisplay -= 1;
                    }
                    else if (numberDisplay <= ScoreManager.singleton.chainReactionMultiplier)
                    {
                        numberDisplay = ScoreManager.singleton.chainReactionMultiplier;
                        this.pass = true;
                    }
                    break;

                case ScoreType.finalScore:
                    if (numberDisplay > ScoreManager.singleton.totalScore)
                    {
                        numberDisplay -= ScoreManager.singleton.totalScore / 100;
                    }
                    else if (numberDisplay <= ScoreManager.singleton.totalScore)
                    {
                        numberDisplay = ScoreManager.singleton.totalScore;
                        this.pass = true;
                    }
                    break;
            }

            if (this.pass)
            {
                eGAnimator.SetTrigger("Game Over");
                this.GetComponent<UIScoreCalculator>().enabled = false;
                this.pass = false;
            }
        }
        else
        {
            Debug.LogError("The gameOver bool in Timer script is set to false.");
        }
    }
}
