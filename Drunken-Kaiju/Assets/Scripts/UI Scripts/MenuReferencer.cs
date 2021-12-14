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

    public void TitleNext()
    {
        Animator anim = gameObject.GetComponent<Animator>();

        anim.SetTrigger("next");
    }

    public void TitleSelectEnable()
    {
        GameObject.Find("Clock UI").GetComponent<MenuSelectUI>().enabled = true;
    }

    public void TitleStopRotatingCamera()
    {
        if(GameObject.Find("Background Rotation Camera"))
        {
            GameObject.Find("Background Rotation Camera").SetActive(false);
        }
    }

    public void LoadintoGame()
    {
        LevelLoader.loader.LoadLevel(1);
    }

    public void EndApplication()
    {
        Application.Quit();
    }
}
