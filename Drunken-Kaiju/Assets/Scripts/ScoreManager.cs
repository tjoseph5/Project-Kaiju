using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;


    public int totalScore;

    public int standardScore;

    public int specialBuildingMultiplier; //Make sure to have a statement where score get multiplied by 1 instead of this variable if this variable equals 0 by the end of the game
    public int chainReactionMultiplier; //Make sure to have a statement where score get multiplied by 1 instead of this variable if this variable equals 0 by the end of the game

    [Range(0, 5)] public float tempCRScoreTimer;
    public int tempCRMultiplier;

    [HideInInspector] public int defaultGivenScore;
    //[HideInInspector] public int deathScore;

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        
    }


    void Update()
    {


        if (tempCRScoreTimer > 0)
        {
            tempCRScoreTimer -= Time.deltaTime;

            if(tempCRScoreTimer > 0)
            {
                defaultGivenScore = 100 * chainReactionMultiplier;
            }
        }
        else if (tempCRScoreTimer <= 0)
        {
            tempCRScoreTimer = 0;
            tempCRMultiplier = 0;
            defaultGivenScore = 100;
        }

        if (Timer.singleton.gameOver)
        {
            if(specialBuildingMultiplier > 0 && chainReactionMultiplier > 0)
            {
                totalScore = standardScore * specialBuildingMultiplier * chainReactionMultiplier;
            }
            else if(specialBuildingMultiplier > 0 && chainReactionMultiplier <= 0)
            {
                totalScore = standardScore * specialBuildingMultiplier;
            }
            else if (specialBuildingMultiplier <= 0 && chainReactionMultiplier > 0)
            {
                totalScore = standardScore * chainReactionMultiplier;
            }
            else
            {
                totalScore = standardScore;
            }
        }
    }
}
