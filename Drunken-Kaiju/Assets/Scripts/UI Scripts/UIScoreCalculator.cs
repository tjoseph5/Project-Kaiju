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

    bool playRank;

    [SerializeField] enum ScoreType { baseScore, specialScore, chainScore, finalScore, rank};
    [SerializeField] ScoreType scoreType = ScoreType.baseScore;

    AudioSource audioSource;

    void Start()
    {
        audioSource = eGAnimator.gameObject.GetComponent<AudioSource>();

        audioSource.loop = true;
        audioSource.clip = JimSFXPool.singleton.menuClips[0];
        audioSource.Play();

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
                if(scoreType == ScoreType.baseScore || scoreType == ScoreType.finalScore)
                {
                    text.text = "¥" + numberDisplay.ToString();
                } 
                else if (scoreType == ScoreType.specialScore || scoreType == ScoreType.chainScore)
                {
                    text.text = "x" + numberDisplay.ToString();
                }
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

                        //AudioStop();
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

                        //AudioStop();
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

                        //AudioStop();
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

                        //AudioStop();
                    }
                    break;

                case ScoreType.rank:

                    if (ScoreManager.singleton.totalScore >= 1000000000)
                    {
                        text.text = "WTF";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 900000000 && ScoreManager.singleton.totalScore < 1000000000)
                    {
                        text.text = "S+++";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 500000000 && ScoreManager.singleton.totalScore < 900000000)
                    {
                        text.text = "S++";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 100000000 && ScoreManager.singleton.totalScore < 500000000)
                    {
                        text.text = "S+";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if (ScoreManager.singleton.totalScore >= 75000000 && ScoreManager.singleton.totalScore < 100000000)
                    {
                        text.text = "S";
                        text.color = new Color(1, 0.85f, 0);
                    }
                    else if(ScoreManager.singleton.totalScore >= 50000000 && ScoreManager.singleton.totalScore < 75000000)
                    {
                        text.text = "A";
                        text.color = Color.red;
                    }
                    else if (ScoreManager.singleton.totalScore >= 25000000 && ScoreManager.singleton.totalScore < 50000000)
                    {
                        text.text = "B";
                        text.color = Color.cyan;
                    }
                    else if (ScoreManager.singleton.totalScore >= 5000000 && ScoreManager.singleton.totalScore < 25000000)
                    {
                        text.text = "C";
                        text.color = new Color(0.7169812f, 0.4876057f, 0.0703453f);
                    }
                    else if (ScoreManager.singleton.totalScore >= 1000000 && ScoreManager.singleton.totalScore < 5000000)
                    {
                        text.text = "D";
                        text.color = Color.green;
                    }
                    else if (ScoreManager.singleton.totalScore < 1000000)
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
                    AudioStop();

                    this.eGAnimator.SetTrigger("Game Over");
                    stop = true;
                }
            } 
            
            else if (this.pass && scoreType == ScoreType.rank)
            {
                Timer.singleton.rankFinished = true;

                AudioStop();
            }
        }
    }

    void AudioStop()
    {
        if (this.audioSource != null)
        {
            audioSource.loop = false;
            audioSource.clip = JimSFXPool.singleton.menuClips[1];
            audioSource.Play();
        }

        this.audioSource = null;
    }
}
