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
            KaijuMovement.singleton.ObjectPickupManager(KaijuMovement.singleton.rayForwardHit.collider.gameObject.GetComponent<Rigidbody>());
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
                }
            }
        }
    }
}
