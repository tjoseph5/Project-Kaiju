using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectUIEnd : MonoBehaviour
{
    public GameObject[] optionCards;

    [SerializeField] [Range(0, 1)] int optionInt;
    int tempOptionIntStore;

    Vector3[] lerpStartPos = new Vector3[2];
    Vector3[] lerpEndPos = new Vector3[2];

    [SerializeField] float desiredDuration;
    float elapsedTime;

    void Start()
    {
        optionInt = 0;

        lerpStartPos[0] = optionCards[0].transform.position;
        lerpStartPos[1] = optionCards[1].transform.position;

        lerpEndPos[0] = new Vector3(optionCards[0].transform.position.x, optionCards[0].transform.position.y + 30, 0);
        lerpEndPos[1] = new Vector3(optionCards[1].transform.position.x, optionCards[1].transform.position.y + 30, 0);
    }

    void Update()
    {
        if (Menu.singleton.navigateU.action.triggered || Menu.singleton.navigateD.action.triggered || Menu.singleton.navigateL.action.triggered || Menu.singleton.navigateR.action.triggered)
        {
            elapsedTime = 0;
        }

        elapsedTime += Time.deltaTime;



        float percentageMax = elapsedTime / desiredDuration;

        if (optionInt > 1)
        {
            optionInt = 0;
        }
        else if (optionInt < 0)
        {
            optionInt = 1;
        }

        if (Menu.singleton.navigateL.action.triggered)
        {
            tempOptionIntStore = optionInt;
            optionInt -= 1;
        }
        else if (Menu.singleton.navigateR.action.triggered)
        {
            tempOptionIntStore = optionInt;
            optionInt += 1;
        }
        else if (Menu.singleton.navigateU.action.triggered && optionInt != 1)
        {
            tempOptionIntStore = optionInt;
            optionInt = 1;
        }
        else if (Menu.singleton.navigateU.action.triggered && optionInt == 1)
        {
            optionInt = tempOptionIntStore;
        }
        else if (Menu.singleton.navigateD.action.triggered && optionInt != 1)
        {
            tempOptionIntStore = optionInt;
            optionInt = 1;
        }
        else if (Menu.singleton.navigateD.action.triggered && optionInt == 1)
        {
            optionInt = tempOptionIntStore;
        }

        switch (optionInt)
        {
            case 0:

                optionCards[0].transform.position = Vector3.Lerp(lerpStartPos[0], lerpEndPos[0], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[1].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[1].x, lerpEndPos[1].y - 30, 0), lerpStartPos[1], Mathf.SmoothStep(0, 1, percentageMax));

                break;

            case 1:

                optionCards[1].transform.position = Vector3.Lerp(lerpStartPos[1], lerpEndPos[1], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[0].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[0].x, lerpEndPos[0].y - 30, 0), lerpStartPos[0], Mathf.SmoothStep(0, 1, percentageMax));

                break;
        }

        if (Timer.singleton.rankFinished)
        {

            if (Menu.singleton.select.action.triggered)
            {
                switch (optionInt)
                {
                    case 0:
                        Menu.singleton.pauseAnimator.SetBool("InEndGame", true);
                        Menu.singleton.pauseAnimator.SetTrigger("play");
                        Debug.Log("Play");
                        break;

                    case 1:
                        Menu.singleton.pauseAnimator.SetBool("InEndGame", true);
                        Menu.singleton.pauseAnimator.SetTrigger("exit");
                        Debug.Log("Return");
                        break;
                }
            }

        }
    }
}
