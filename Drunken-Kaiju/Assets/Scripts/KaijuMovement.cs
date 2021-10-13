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

    #region Raycast Setup
    Vector3 rayForwardDir; //raycast vector that places the raycast's position
    [SerializeField] float rayForwardLength; //length of raycast
    RaycastHit rayForwardHit; //raycast collider

    Vector3 rayDownDir;
    [SerializeField] float rayDownLength;
    RaycastHit rayDownHit;
    #endregion


    void Awake()
    {
        rayForwardDir = hip.transform.TransformVector(hip.gameObject.transform.forward);
        rayDownDir = hip.transform.TransformVector(-hip.gameObject.transform.up);
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cameraMainTransform = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        movement = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y).normalized;
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;

        if(Physics.Raycast(transform.position, rayDownDir, out rayDownHit, rayDownLength, 1 << 6))
        {
            if (rayDownHit.collider.tag == "Untagged")
            {
                isGrounded = true;

                if (jumpControl.action.triggered)
                {
                    Debug.Log("jump");
                    this.hip.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                    targetAnimator.SetTrigger("Jump");
                }
            }
            else
            {
                isGrounded = false;
            }
        }

        
        if (jumpControl.action.triggered)
        {
            Debug.Log("jump");
            this.hip.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            targetAnimator.SetTrigger("Jump");
        }
        

        this.targetAnimator.SetBool("Walk", this.walk);

        if (movement.magnitude > 0) //This makes sure that the direction of the raycast is always positioned to the player's forward axis (front z axis)
        {
            rayForwardDir = hip.transform.forward.normalized;
        }

        rayDownDir = -hip.transform.up.normalized;

        Debug.DrawRay(hip.transform.position, rayForwardDir * rayForwardLength, Color.red); //raycast debug
        Debug.DrawRay(hip.transform.position, rayDownDir * rayDownLength, Color.red); //raycast debug
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

        switch (isGrounded)
        {
            case true:
                if (hip.velocity.magnitude > groundSpeedCap)
                {
                    hip.velocity = Vector3.ClampMagnitude(hip.velocity, groundSpeedCap);
                    //Debug.Log("Clamped Ground Speed");
                }
                break;

            case false:
                if (hip.velocity.magnitude > velocityCap)
                {
                    hip.velocity = Vector3.ClampMagnitude(hip.velocity, velocityCap);
                    //Debug.Log("Clamped Overall Speed");
                }
                break;
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
