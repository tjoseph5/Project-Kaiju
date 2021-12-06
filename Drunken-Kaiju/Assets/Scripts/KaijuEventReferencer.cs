using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuEventReferencer : MonoBehaviour
{
    public static KaijuEventReferencer animReferencer;

    void Awake()
    {
        animReferencer = this;
    }

    public void ThrowReferencer()
    {
        if (KaijuMovement.singleton.heldObj != null)
        {
            KaijuMovement.singleton.ObjectPickupManager(KaijuMovement.singleton.heldObj.GetComponent<Rigidbody>(), true);
        }
        
    }

    public void GrabReferencer()
    {
        if(KaijuMovement.singleton.heldObj == null)
        {
            if (Physics.Raycast(KaijuMovement.singleton.rootRb.transform.position, KaijuMovement.singleton.rayForwardDir, out KaijuMovement.singleton.rayForwardHit, KaijuMovement.singleton.rayForwardLength, ~KaijuMovement.singleton.playerLayerMask))
            {
                if (KaijuMovement.singleton.rayForwardHit.collider.GetComponent<ThrowableObject>() && KaijuMovement.singleton.rayForwardHit.collider.GetComponent<Rigidbody>())
                {
                    if (KaijuMovement.singleton.rayForwardHit.collider.GetComponent<ThrowableObject>().canBeHeld) //This part of the code may be redundant to include
                    {
                        KaijuMovement.singleton.ObjectPickupManager(KaijuMovement.singleton.rayForwardHit.collider.gameObject.GetComponent<Rigidbody>());
                    }
                }
                else if(KaijuMovement.singleton.rayForwardHit.collider == null)
                {
                    Debug.Log("nothing here");
                }
            }

        }
    }

    
    public void ObjectLayerReset()
    {
        
        if(KaijuMovement.singleton.heldObj != null)
        {
            if (KaijuMovement.singleton.heldObj.layer == 8)
            {
                KaijuMovement.singleton.heldObj.layer = 0;
            }
        }

        KaijuMovement.singleton.heldObj = null;
    }

    public void AttackReferencer()
    {
        if (Physics.Raycast(KaijuMovement.singleton.rootRb.transform.position, KaijuMovement.singleton.rayAttackDir, out KaijuMovement.singleton.rayAttackHit, KaijuMovement.singleton.rayAttackLength, ~KaijuMovement.singleton.playerLayerMask))
        {
            if (KaijuMovement.singleton.rayAttackHit.collider.gameObject.GetComponent<DestructableObject>())
            {
                if(KaijuMovement.singleton.rayAttackHit.collider.gameObject.GetComponent<DestructableObject>().health > 0)
                {
                    KaijuMovement.singleton.rayAttackHit.collider.gameObject.GetComponent<DestructableObject>().health -= 25;
                    KaijuMovement.singleton.rayAttackHit.collider.gameObject.GetComponent<DestructableObject>().recentlyHit = true;

                    KaijuMovement.singleton.PlayAudio(7);
                }
            }
        }
    }

    public void WalkAudioReferencer()
    {
        //volume = KaijuMovement.singleton.audioSource.volume;

        if (KaijuMovement.singleton.isGrounded)
        {
            KaijuMovement.singleton.PlayAudio(0);
        }
    }

    public void GrabP1AudioReferencer()
    {
        KaijuMovement.singleton.PlayAudio(3);
    }

    public void GrabP2AudioReferencer()
    {
        KaijuMovement.singleton.PlayAudio(4);
    }

    public void ThrowAudioReferencer()
    {
        KaijuMovement.singleton.PlayAudio(5);
    }
}
