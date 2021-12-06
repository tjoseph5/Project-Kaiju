using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSFXHit : MonoBehaviour
{
    [HideInInspector] public bool hitGround;

    private void Start()
    {
        hitGround = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == 9 && KaijuMovement.singleton.activateRagdoll && !this.hitGround)
        {
            KaijuMovement.singleton.audioSource.volume = 0.1f;
            KaijuMovement.singleton.audioSource.pitch = 0.75f;
            KaijuMovement.singleton.audioSource.PlayOneShot(JimSFXPool.singleton.jimClips[0]);
            hitGround = true;
        }  
    }
}
