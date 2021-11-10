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
        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().mass = 0.001f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.name = "shard";

        if (gameObject.GetComponent<Rigidbody>())
        {
            if(KaijuMovement.singleton.activateRagdoll == true)
            {
                gameObject.GetComponent<Rigidbody>().mass = 0.5f;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().mass = 0.001f;
            }
            
        }
    }

    void OnDestroy()
    {
        ShardManager.singleton.shards.Remove(gameObject);
    }
}
