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

    [SerializeField] enum ScoreType { baseScore, specialScore, chainScore, finalScore, rank};
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
            if(scoreType != ScoreType.rank)
            {
                text.text = numberDisplay.ToString();
            }

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

                case ScoreType.rank:

                    if(ScoreManager.singleton.totalScore >= 100000)
                    {
                        text.text = "S";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if(ScoreManager.singleton.totalScore >= 75000 && ScoreManager.singleton.totalScore < 100000)
                    {
                        text.text = "A";
                        text.color = Color.red;
                    }
                    else if (ScoreManager.singleton.totalScore >= 50000 && ScoreManager.singleton.totalScore < 75000)
                    {
                        text.text = "B";
                        text.color = Color.cyan;
                    }
                    else if (ScoreManager.singleton.totalScore >= 25000 && ScoreManager.singleton.totalScore < 50000)
                    {
                        text.text = "C";
                        text.color = new Color(0.7169812f, 0.4876057f, 0.0703453f);
                    }
                    else if (ScoreManager.singleton.totalScore >= 10000 && ScoreManager.singleton.totalScore < 25000)
                    {
                        text.text = "D";
                        text.color = Color.green;
                    }
                    else if (ScoreManager.singleton.totalScore < 10000)
                    {
                        text.text = "E";
                        text.color = Color.black;
                    }
                    break;
            }

            if (this.pass && scoreType != ScoreType.rank)
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
