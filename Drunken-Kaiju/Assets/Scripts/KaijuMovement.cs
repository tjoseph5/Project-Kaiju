using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KaijuMovement : MonoBehaviour
{

    Rigidbody rb;

    #region Controller Input Actions
    public InputActionReference movementControl;
    public InputActionReference jumpControl;
    #endregion

    #region Camera Stuff
    private Transform cameraMainTransform;

    #endregion

    [SerializeField] float speed;
    [SerializeField] ConfigurableJoint hipJoint;
    [SerializeField] Rigidbody hip;

    [SerializeField] Animator targetAnimator;

    bool walk = false;


    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cameraMainTransform = GameObject.Find("Main Camera").transform;
    }


    void Update()
    {
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y).normalized;



        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.z, move.x) * Mathf.Rad2Deg;

            this.hipJoint.targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            this.hip.AddForce(move * this.speed);

            this.walk = true;
        }
        else
        {
            this.walk = false;
        }

        this.targetAnimator.SetBool("Walk", this.walk);

        if (jumpControl.action.triggered)
        {
            Debug.Log("jump");
        }
    }

    #region Input Enable / Disable stuff
    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
    }
    #endregion
}
