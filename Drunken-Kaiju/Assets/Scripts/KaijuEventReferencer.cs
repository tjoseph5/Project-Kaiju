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
}
