using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickDisableEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Menu.singleton.menuStates == Menu.MenuStates.endGame)
        {
            gameObject.SetActive(false);
        }
    }
}
