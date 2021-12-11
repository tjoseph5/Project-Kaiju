using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public static LevelLoader loader;

    public GameObject loadingScreen;
    public Slider slider;

    private void Awake()
    {
        loader = this;
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAysnchronously(sceneIndex));
        
    }

    IEnumerator LoadAysnchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            yield return null;
        }
    }

}
