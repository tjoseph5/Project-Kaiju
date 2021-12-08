using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuReferencer : MonoBehaviour
{

    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void TimeCardSlideSFX()
    {
        audioSource.volume = 0.5f;
        audioSource.PlayOneShot(JimSFXPool.singleton.menuClips[2]);
    }

    public void ResumeGame()
    {
        Menu.singleton.Resume();
    }
}