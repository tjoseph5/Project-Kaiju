using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuEventReferencer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
