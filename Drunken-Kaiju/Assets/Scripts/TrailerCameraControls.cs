using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TrailerCameraControls : MonoBehaviour
{

    Vector2 inputValue;
    Vector3 move;
    public InputActionReference movementControl;

    Vector2 r_inputValue;
    Vector3 rotate;
    public InputActionReference rotationControl;

    [SerializeField] float speed;

    public InputActionReference elevation;
    public InputActionReference decend;

    public InputActionReference cameraShutdown;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputValue = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(inputValue.x, 0, inputValue.y).normalized;


        if (elevation.action.ReadValue<float>() == 1)
        {
            move.y = 1;
        }

        if (decend.action.ReadValue<float>() == 1)
        {
            move.y = -1;
        }

        transform.Translate(move * speed);

        r_inputValue = rotationControl.action.ReadValue<Vector2>();
        rotate = new Vector3(r_inputValue.y, r_inputValue.x, 0).normalized;

        transform.Rotate(rotate * speed);

        if(transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }

        if (cameraShutdown.action.triggered)
        {
            EnterGameplayMode();
        }
    }

    void EnterGameplayMode()
    {
        Destroy(gameObject);
        GameObject.Find("Main Camera").GetComponent<Camera>().enabled = true;
    }

    void OnEnable()
    {
        movementControl.action.Enable();
        rotationControl.action.Enable();

        elevation.action.Enable();
        decend.action.Enable();

        cameraShutdown.action.Enable();
    }

    void OnDisable()
    {
        movementControl.action.Disable();
        rotationControl.action.Disable();

        elevation.action.Disable();
        decend.action.Disable();

        cameraShutdown.action.Disable();
    }
}
