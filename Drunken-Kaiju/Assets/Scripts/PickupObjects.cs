using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    public enum PickupTypes { healthPickup, bottlePickup, clockPickup };
    public PickupTypes pickupTypes = PickupTypes.healthPickup;

    GameObject player;

    [HideInInspector] public bool hasDrank;

    public float rotateSpeed;

    AudioSource audioSource;

    [SerializeField] GameObject pickupVFX;

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

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        this.transform.Rotate(0f, rotateSpeed, 0f);

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

        if (pickupTypes == PickupTypes.bottlePickup)
        {
            if (hasDrank)
            {
                PlayBottleAudio(0, 0.2f);
            }
        }
    }

    void OnCollisionStay(Collision col)
    {
        if(pickupTypes == PickupTypes.bottlePickup)
        {
            if (col.gameObject.layer == 9)
            {
                if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 1)
                {
                    if(audioSource.isPlaying == false)
                    {
                        PlayBottleAudio(1, 0.05f, true);
                    }
                }
                else
                {
                    audioSource.loop = false;
                    audioSource.Stop();
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
                    if(Timer.singleton.gameOver == false && Timer.singleton.minutes < 3)
                    {
                        Timer.singleton.minutes += 1;
                        Destroy(gameObject);
                        GameObject vFX = Instantiate(pickupVFX, transform.position, transform.rotation, null);
                    }
                    else if(Timer.singleton.gameOver == false && Timer.singleton.minutes >= 3)
                    {
                        Timer.singleton.minutes = 3;
                        Timer.singleton.seconds = 59;
                        Destroy(gameObject);
                        GameObject vFX = Instantiate(pickupVFX, transform.position, transform.rotation, null);
                    }

                    break;
            }
        }
    }

    public void BottlePickup()
    {
        PlayBottleAudio(3);

        hasDrank = true;
        //gameObject.layer = 8;
        KaijuMovement.singleton.pukeAmount += 25;
        gameObject.GetComponent<ThrowableObject>().enabled = true;
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        ScoreManager.singleton.standardScore += 150;
        GameObject vFX = Instantiate(pickupVFX, transform.position, transform.rotation, null);
    }

    void PlayBottleAudio(int clip, float volume = 0.45f, bool looping = false)
    {
        audioSource.loop = looping;
        audioSource.volume = volume;
        audioSource.PlayOneShot(JimSFXPool.singleton.bottleClips[clip]);
    }
}
