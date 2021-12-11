using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardManager : MonoBehaviour
{
    public static ShardManager singleton;

    [HideInInspector] public List<GameObject> shards = new List<GameObject>();

    void Awake()
    {
        singleton = this;
    }

    void Start()
    {
        
    }


    void Update()
    {
        if(shards.Count > 50)
        {
            shards.RemoveRange(0, 5);
        }
    }
}
