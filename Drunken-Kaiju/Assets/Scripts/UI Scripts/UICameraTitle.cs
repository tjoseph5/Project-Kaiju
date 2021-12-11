using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICameraTitle : MonoBehaviour
{
    public GameObject centre;

    public float rotationSpeed;

    void Update()
    {
        transform.RotateAround(centre.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
