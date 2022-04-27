using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAudioReference : MonoBehaviour
{

    public bool isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;

        if (/*KaijuMovement.singleton.walk &&*/ isGrounded && collision.gameObject.layer == 9)
        {
            KaijuEventReferencer.animReferencer.WalkAudioReferencer();

            if (!KaijuMovement.singleton.activateRagdoll)
            {
                Instantiate(KaijuEventReferencer.animReferencer.walkDustVFX, this.transform.position, this.transform.rotation);
            }
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        //KaijuEventReferencer.animReferencer.WalkAudioReferencer();
    }
}
