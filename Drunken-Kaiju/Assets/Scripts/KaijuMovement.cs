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
    [SerializeField] float jumpHeight;
    [SerializeField] ConfigurableJoint hipJoint;
    [SerializeField] Rigidbody hip;

    [SerializeField] Animator targetAnimator;

    bool walk = false;

    [Range(1,30)] [SerializeField] float velocityCap;
    [Range(1, 3)] [SerializeField] float groundSpeedCap;

    Vector2 movement;
    Vector3 move;

    [SerializeField] bool isGrounded;

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        cameraMainTransform = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        movement = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y).normalized;
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;


        if (jumpControl.action.triggered)
        {
            Debug.Log("jump");
            this.hip.AddForce(new Vector3 (0, jumpHeight, 0), ForceMode.Impulse);
        }

        this.targetAnimator.SetBool("Walk", this.walk);
    }

    void FixedUpdate()
    {
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.z, move.x) * Mathf.Rad2Deg;

            this.hipJoint.targetRotation = Quaternion.Euler(0f, targetAngle + 90, 0f);

            this.hip.AddForce(move * this.speed);

            this.walk = true;
        }
        else
        {
            this.walk = false;
        }

        if (isGrounded)
        {
            if (hip.velocity.magnitude > groundSpeedCap)
            {
                hip.velocity = Vector3.ClampMagnitude(hip.velocity, groundSpeedCap);
            }
        }
        else
        {
            if (hip.velocity.magnitude > velocityCap)
            {
                hip.velocity = Vector3.ClampMagnitude(hip.velocity, velocityCap);
            }
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
