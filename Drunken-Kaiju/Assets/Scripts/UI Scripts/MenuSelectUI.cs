using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectUI : MonoBehaviour
{
    //THIS SCRIPT SHOULD BE ATTACHED TO THE SELECT UI AND IS MAINLY USED TO CONTROL SELECTING PARTS OF THE MENU.

    public GameObject[] optionCards;
    public GameObject[] dynamicCameras;

    [SerializeField] [Range(0, 3)] int optionInt;
    [SerializeField] int tempOptionIntStore;

    void Start()
    {
        optionInt = 0;
    }

    void Update()
    {

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

        switch (Menu.singleton.sceneID)
        {
            case 0:
                if (Menu.singleton.titleStarted)
                {
                    
                }
                break;

            case 1:

                break;
        }
    }
}
