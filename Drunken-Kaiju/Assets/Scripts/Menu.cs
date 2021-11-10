using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{

    [SerializeField] InputActionReference select;

    Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (select.action.triggered)
        {
            select.action.Disable();

            if(scene.buildIndex == 0)
            {
                if(!Timer.singleton.timeStart && Timer.singleton.gameOver && Timer.singleton.rankFinished)
                {
                    SceneManager.LoadScene(0);
                }

            }
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
