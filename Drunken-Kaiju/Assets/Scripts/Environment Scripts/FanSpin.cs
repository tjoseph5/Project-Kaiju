using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//All this script does is animate the fans to spin
public class FanSpin : MonoBehaviour
{
    public float speed;

    void Update()
    {
        this.transform.Rotate(speed, 0f, 0f);
    }
}
