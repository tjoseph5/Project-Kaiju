using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager singleton;

    public GameObject[] destroyedBuildings;

    private void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        //gameObject.hideFlags = HideFlags.HideInHierarchy;
    }
}
