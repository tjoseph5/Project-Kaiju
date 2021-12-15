using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelLoader.loader.LoadLevel(1);
    }

}
