using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShardSingular : MonoBehaviour
{

    AudioSource audioSource;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        ShardManager.singleton.shards.Add(gameObject);
        Destroy(gameObject, 10f);
        if (gameObject.GetComponent<Rigidbody>())
        {
            gameObject.GetComponent<Rigidbody>().mass = 0.5f;
        }

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.name = "shard";

        if (gameObject.GetComponent<Rigidbody>())
        {
            if(KaijuMovement.singleton.activateRagdoll == true)
            {
                if (KaijuMovement.singleton.dashAttack)
                {
                    //Physics.IgnoreLayerCollision(6, 7, false);
                    //gameObject.GetComponent<Rigidbody>().mass = 0.5f;
                }

                Physics.IgnoreLayerCollision(6, 7, false);
                gameObject.GetComponent<Rigidbody>().mass = 0.5f;
            }

            if (KaijuMovement.singleton.activateRagdoll == false)
            {
                gameObject.GetComponent<Rigidbody>().mass = 0.001f;
                Physics.IgnoreLayerCollision(6, 7, true);
            }
        }

    }

    void OnDestroy()
    {
        ShardManager.singleton.shards.Remove(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 9 && rb.velocity.sqrMagnitude > 1)
        {
            audioSource.Play();
        }
    }
}
