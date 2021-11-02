using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardSingular : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShardManager.singleton.shards.Add(gameObject);
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.name = "shard";
    }

    void OnDestroy()
    {
        ShardManager.singleton.shards.Remove(gameObject);
    }
}
