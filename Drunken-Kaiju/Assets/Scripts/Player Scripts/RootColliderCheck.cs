using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootColliderCheck : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 9)
        {
            if (KaijuMovement.singleton.activateRagdoll == true)
            {
                //KaijuMovement.singleton.audioSource.PlayOneShot(JimSFXPool.singleton.audioClips[3]);
            }
        }
    }
}
