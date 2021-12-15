using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectUI : MonoBehaviour
{
    //THIS SCRIPT SHOULD BE ATTACHED TO THE SELECT UI AND IS MAINLY USED TO CONTROL SELECTING PARTS OF THE MENU.

    public GameObject[] optionCards;
    public GameObject[] dynamicCameras;

    [SerializeField] [Range(0, 3)] int optionInt;
    int tempOptionIntStore;

    Vector3 [] lerpStartPos = new Vector3[4];
    Vector3 [] lerpEndPos = new Vector3[4];

    [SerializeField] float desiredDuration;
    float elapsedTime;

    void Start()
    {
        optionInt = 0;

        lerpStartPos[0] = optionCards[0].transform.position;
        lerpStartPos[1] = optionCards[1].transform.position;
        lerpStartPos[2] = optionCards[2].transform.position;
        lerpStartPos[3] = optionCards[3].transform.position;

        lerpEndPos[0] = new Vector3(optionCards[0].transform.position.x, optionCards[0].transform.position.y + 30, 0);
        lerpEndPos[1] = new Vector3(optionCards[1].transform.position.x, optionCards[1].transform.position.y + 30, 0);
        lerpEndPos[2] = new Vector3(optionCards[2].transform.position.x, optionCards[2].transform.position.y + 30, 0);
        lerpEndPos[3] = new Vector3(optionCards[3].transform.position.x, optionCards[3].transform.position.y - 30, 0);

        if(Menu.singleton.sceneID != 0)
        {
            foreach(GameObject cam in dynamicCameras)
            {
                dynamicCameras = null;
            }
        }
    }

    void Update()
    {
        if (Menu.singleton.navigateU.action.triggered || Menu.singleton.navigateD.action.triggered || Menu.singleton.navigateL.action.triggered || Menu.singleton.navigateR.action.triggered)
        {
            elapsedTime = 0;
        }

        if(Menu.singleton.sceneID == 0)
        {
            elapsedTime += Time.deltaTime;
        } 
        else if(Menu.singleton.sceneID == 1)
        {
            elapsedTime += Time.unscaledDeltaTime;
        }
        

        float percentageMax = elapsedTime / desiredDuration;

        if (optionInt > 3)
        {
            optionInt = 0;
        } 
        else if(optionInt < 0)
        {
            optionInt = 3;
        }

        if(Menu.singleton.navigateL.action.triggered)
        {
            tempOptionIntStore = optionInt;
            optionInt -= 1;
        }
        else if (Menu.singleton.navigateR.action.triggered)
        {
            tempOptionIntStore = optionInt;
            optionInt += 1;
        }
        else if (Menu.singleton.navigateU.action.triggered && optionInt != 3)
        {
            tempOptionIntStore = optionInt;
            optionInt = 3;
        }
        else if (Menu.singleton.navigateU.action.triggered && optionInt == 3)
        {
            optionInt = tempOptionIntStore;
        }
        else if (Menu.singleton.navigateD.action.triggered && optionInt != 3)
        {
            tempOptionIntStore = optionInt;
            optionInt = 3;
        }
        else if (Menu.singleton.navigateD.action.triggered && optionInt == 3)
        {
            optionInt = tempOptionIntStore;
        }

        switch (optionInt)
        {
            case 0:

                if(Menu.singleton.sceneID == 0)
                {
                    dynamicCameras[1].SetActive(true);
                    dynamicCameras[2].SetActive(false);
                    dynamicCameras[3].SetActive(false);
                    dynamicCameras[4].SetActive(false);
                }
                

                optionCards[0].transform.position = Vector3.Lerp(lerpStartPos[0], lerpEndPos[0], Mathf.SmoothStep(0, 1, percentageMax));

                optionCards[1].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[1].x, lerpEndPos[1].y - 30, 0), lerpStartPos[1], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[2].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[2].x, lerpEndPos[2].y - 30, 0), lerpStartPos[2], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[3].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[3].x, lerpEndPos[3].y + 30, 0), lerpStartPos[3], Mathf.SmoothStep(0, 1, percentageMax));

                break;

            case 1:

                if (Menu.singleton.sceneID == 0)
                {
                    dynamicCameras[1].SetActive(false);
                    dynamicCameras[2].SetActive(true);
                    dynamicCameras[3].SetActive(false);
                    dynamicCameras[4].SetActive(false);
                }


                optionCards[1].transform.position = Vector3.Lerp(lerpStartPos[1], lerpEndPos[1], Mathf.SmoothStep(0, 1, percentageMax));

                optionCards[0].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[0].x, lerpEndPos[0].y - 30, 0), lerpStartPos[0], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[2].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[2].x, lerpEndPos[2].y - 30, 0), lerpStartPos[2], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[3].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[3].x, lerpEndPos[3].y + 30, 0), lerpStartPos[3], Mathf.SmoothStep(0, 1, percentageMax));

                break;

            case 2:

                if(Menu.singleton.sceneID == 0)
                {
                    dynamicCameras[1].SetActive(false);
                    dynamicCameras[2].SetActive(false);
                    dynamicCameras[3].SetActive(true);
                    dynamicCameras[4].SetActive(false);
                }
                

                optionCards[2].transform.position = Vector3.Lerp(lerpStartPos[2], lerpEndPos[2], Mathf.SmoothStep(0, 1, percentageMax));

                optionCards[0].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[0].x, lerpEndPos[0].y - 30, 0), lerpStartPos[0], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[1].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[1].x, lerpEndPos[1].y - 30, 0), lerpStartPos[1], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[3].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[3].x, lerpEndPos[3].y + 30, 0), lerpStartPos[3], Mathf.SmoothStep(0, 1, percentageMax));

                break;

            case 3:

                if (Menu.singleton.sceneID == 0)
                {
                    dynamicCameras[1].SetActive(false);
                    dynamicCameras[2].SetActive(false);
                    dynamicCameras[3].SetActive(false);
                    dynamicCameras[4].SetActive(true);
                }
                

                optionCards[3].transform.position = Vector3.Lerp(lerpStartPos[3], lerpEndPos[3], Mathf.SmoothStep(0, 1, percentageMax));

                optionCards[1].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[1].x, lerpEndPos[1].y - 30, 0), lerpStartPos[1], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[2].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[2].x, lerpEndPos[2].y - 30, 0), lerpStartPos[2], Mathf.SmoothStep(0, 1, percentageMax));
                optionCards[0].transform.position = Vector3.Lerp(new Vector3(lerpEndPos[0].x, lerpEndPos[0].y - 30, 0), lerpStartPos[0], Mathf.SmoothStep(0, 1, percentageMax));

                break;
        }



        switch (Menu.singleton.sceneID)
        {
            case 0:
                if (Menu.singleton.titleStarted)
                {
                    switch (Menu.singleton.menuStates)
                    {
                        case Menu.MenuStates.mainMenu:
                            if (Menu.singleton.select.action.triggered)
                            {
                                switch (optionInt)
                                {
                                    case 0:
                                        Menu.singleton.pauseAnimator.SetTrigger("play");
                                        Debug.Log("Play");
                                        break;

                                    case 1:
                                        Menu.singleton.pauseAnimator.SetTrigger("htp");
                                        Menu.singleton.menuStates = Menu.MenuStates.howToPlay;
                                        Debug.Log("HTP");
                                        break;

                                    case 2:
                                        Menu.singleton.pauseAnimator.SetTrigger("exit");
                                        Debug.Log("Exit");
                                        break;

                                    case 3:
                                        Menu.singleton.pauseAnimator.SetTrigger("credits");
                                        Menu.singleton.menuStates = Menu.MenuStates.howToPlay;
                                        Debug.Log("Credit");
                                        break;
                                }
                            }
                            break;
                    }
                }
                break;

            case 1:
                if (!Timer.singleton.gameOver && !Timer.singleton.timeStart && !Timer.singleton.rankFinished)
                {
                    switch (Menu.singleton.menuStates)
                    {
                        case Menu.MenuStates.inGame:
                            if (Menu.singleton.select.action.triggered)
                            {
                                switch (optionInt)
                                {
                                    case 0:
                                        Menu.singleton.pauseAnimator.SetTrigger("Pause");
                                        Debug.Log("Play");
                                        break;

                                    case 1:
                                        Menu.singleton.pauseAnimator.SetTrigger("htp");
                                        Menu.singleton.menuStates = Menu.MenuStates.howToPlay;
                                        Debug.Log("HTP");
                                        break;

                                    case 2:
                                        Menu.singleton.pauseAnimator.SetTrigger("play");
                                        Debug.Log("Restart");
                                        break;

                                    case 3:
                                        Menu.singleton.pauseAnimator.SetTrigger("exit");
                                        Menu.singleton.menuStates = Menu.MenuStates.howToPlay;
                                        Debug.Log("BTM");
                                        break;
                                }
                            }
                            break;
                    }
                }
                break;
        }
    }
}
