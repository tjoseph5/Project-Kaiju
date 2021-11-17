using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIScoreCalculator : MonoBehaviour
{

    public Animator eGAnimator;
    public TextMeshProUGUI text;
    int numberDisplay;

    bool pass;
    bool stop;

    [SerializeField] enum ScoreType { baseScore, specialScore, chainScore, finalScore, rank};
    [SerializeField] ScoreType scoreType = ScoreType.baseScore;


    void Start()
    {
        //this.eGAnimator = UIManager.singleton.endGameUI.GetComponent<Animator>();
        //text = gameObject.GetComponent<TextMeshProUGUI>();

        switch (scoreType)
        {
            case ScoreType.baseScore:
                numberDisplay = 0;
                break;

            case ScoreType.specialScore:
                numberDisplay = 0;
                break;

            case ScoreType.chainScore:
                numberDisplay = 0;
                break;

            case ScoreType.finalScore:
                numberDisplay = 0;
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
                    if (numberDisplay < ScoreManager.singleton.standardScore)
                    {
                        numberDisplay += (ScoreManager.singleton.standardScore / 100);
                    }
                    else if (numberDisplay >= ScoreManager.singleton.standardScore)
                    {
                        numberDisplay = ScoreManager.singleton.standardScore;
                        this.pass = true;
                    }
                    break;

                case ScoreType.specialScore:
                    if (numberDisplay < ScoreManager.singleton.specialBuildingMultiplier)
                    {
                        numberDisplay += 1;
                    }
                    else if (numberDisplay >= ScoreManager.singleton.specialBuildingMultiplier)
                    {
                        numberDisplay = ScoreManager.singleton.specialBuildingMultiplier;
                        this.pass = true;
                    }
                    break;

                case ScoreType.chainScore:
                    if (numberDisplay < ScoreManager.singleton.chainReactionMultiplier)
                    {
                        numberDisplay += 1;
                    }
                    else if (numberDisplay >= ScoreManager.singleton.chainReactionMultiplier)
                    {
                        numberDisplay = ScoreManager.singleton.chainReactionMultiplier;
                        this.pass = true;
                    }
                    break;

                case ScoreType.finalScore:
                    if (numberDisplay < ScoreManager.singleton.totalScore)
                    {
                        numberDisplay += (ScoreManager.singleton.totalScore / 100);
                    }
                    else if (numberDisplay >= ScoreManager.singleton.totalScore)
                    {
                        numberDisplay = ScoreManager.singleton.totalScore;
                        this.pass = true;
                    }
                    break;

                case ScoreType.rank:

                    if (ScoreManager.singleton.totalScore >= 1500000)
                    {
                        text.text = "S+++";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 1000000 && ScoreManager.singleton.totalScore < 1500000)
                    {
                        text.text = "S++";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 500000 && ScoreManager.singleton.totalScore < 1000000)
                    {
                        text.text = "S+";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 100000 && ScoreManager.singleton.totalScore < 500000)
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
                    this.pass = true;
                    break;
            }

            if (this.pass && scoreType != ScoreType.rank)
            {
                if (!this.stop)
                {
                    this.eGAnimator.SetTrigger("Game Over");
                    stop = true;
                }
            } 
            
            else if (this.pass && scoreType == ScoreType.rank)
            {
                Timer.singleton.rankFinished = true;
            }
        }
    }
}
