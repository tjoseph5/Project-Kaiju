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
        if(Menu.singleton.sceneID == 1)
        {
            Menu.singleton.Resume();
        }
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
        if(Menu.singleton.sceneID == 0)
        {
            LevelLoader.loader.LoadLevel(1);
        }
    }

    public void EndApplication()
    {
        Application.Quit();
    }

    public void PauseTriggerReset()
    {
        Menu.singleton.pauseAnimator.ResetTrigger("Pause");
    }

    public void LoadintoDummy()
    {
        if (Menu.singleton.sceneID == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }

    public void LoadintoMain()
    {
        LevelLoader.loader.LoadLevel(0);
    }
}
