using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    public enum PickupTypes { healthPickup, bottlePickup, clockPickup };
    public PickupTypes pickupTypes = PickupTypes.healthPickup;

    GameObject player;

    [HideInInspector] public bool hasDrank;

    void Start()
    {
        player = null;

        switch (pickupTypes)
        { 
            case PickupTypes.healthPickup:
                gameObject.name = "Health Pickup";
                break;
            case PickupTypes.bottlePickup:
                gameObject.name = "Bottle Pickup";
                gameObject.tag = "Interactable";
                if(gameObject.GetComponent<Rigidbody>().isKinematic != true)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
                break;
            case PickupTypes.clockPickup:
                gameObject.name = "Clock Pickup";
                break;
        }
    }

    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision col)
    {
        if(pickupTypes == PickupTypes.bottlePickup && KaijuMovement.singleton.pukeAmount < 100)
        {
            if (col.gameObject.tag == "Player")
            {
                if (player == null)
                {
                    player = col.gameObject;
                    Debug.Log("Player collision is now: " + player.name);
                }
            }
        }

        if (col.gameObject == player)
        {
            if (pickupTypes == PickupTypes.bottlePickup)
            {
                if (KaijuMovement.singleton.pukeAmount < 100)
                {
                    if (!this.hasDrank)
                    {
                        gameObject.layer = 0;
                        BottlePickup();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(pickupTypes == PickupTypes.clockPickup || pickupTypes == PickupTypes.healthPickup && KaijuMovement.singleton.health < 100)
        {
            if (other.gameObject.tag == "Player")
            {
                if (player == null)
                {
                    player = other.gameObject;
                    Debug.Log("Player collision is now: " + player.name);
                }
            }
        }

        if (other.gameObject == player)
        {
            ScoreManager.singleton.standardScore += 150;

            switch (pickupTypes)
            {
                case PickupTypes.healthPickup:

                    if (KaijuMovement.singleton.health < 100)
                    {
                        KaijuMovement.singleton.health += 25;
                        Destroy(gameObject);
                    }

                    break;

                case PickupTypes.clockPickup:
                    //Add Clock Pickup
                    Destroy(gameObject);
                    break;
            }
        }
    }

    public void BottlePickup()
    {
        hasDrank = true;
        //gameObject.layer = 8;
        KaijuMovement.singleton.pukeAmount += 25;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        ScoreManager.singleton.standardScore += 150;
    }
}
