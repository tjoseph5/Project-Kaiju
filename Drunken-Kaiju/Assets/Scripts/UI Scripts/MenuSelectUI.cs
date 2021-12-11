using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelectUI : MonoBehaviour
{
    //THIS SCRIPT SHOULD BE ATTACHED TO THE SELECT UI AND IS MAINLY USED TO CONTROL SELECTING PARTS OF THE MENU.
    Vector2 navigationVector;



    void Start()
    {
        
    }

    void Update()
    {
        navigationVector = Menu.singleton.navigate.action.ReadValue<Vector2>().normalized;
    }
}
