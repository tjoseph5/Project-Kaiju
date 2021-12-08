using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] InputActionReference select;

    Scene scene;

    int sceneID;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();

        sceneID = scene.buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        switch (sceneID)
        {
            case 0:
                if (select.action.triggered)
                {
                    select.action.Disable();

                    LevelLoader.loader.LoadLevel(1);
                }
                break;

            case 1:
                break;
        }
    }

    private void OnEnable()
    {
        select.action.Enable();
    }

    private void OnDisable()
    {
        select.action.Disable();
    }
}
