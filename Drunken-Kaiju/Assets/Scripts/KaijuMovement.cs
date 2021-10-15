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
    bool inAir = false;

    [Range(1,60)] [SerializeField] float velocityCap;
    [Range(1, 4)] [SerializeField] float groundSpeedCap;

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

    LayerMask playerLayerMask = 1 << 6;
    #endregion

    #region Config Joint Spring Position Store
    float rootJoint_spring;
    float chestJoint_spring;
    float l_ShouderJoint_spring;
    float l_ElbowJoint_spring;
    float r_ShoulderJoint_spring;
    float r_ElbowJoint_spring;
    float neckJoint_spring;
    float l_HipJoint_spring;
    float l_KneeJoint_spring;
    float l_FootJoint_spring;
    float r_HipJoint_spring;
    float r_KneeJoint_spring;
    float r_FootJoint_spring;
    float tailJoint_spring;
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

        #region Config Joint Spring Position Store Setup
        rootJoint_spring = hipJoint.angularXDrive.positionSpring;
        chestJoint_spring = hip.transform.GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        l_ShouderJoint_spring = hip.transform.GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        l_ElbowJoint_spring = hip.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        r_ShoulderJoint_spring = hip.transform.GetChild(0).GetChild(2).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        r_ElbowJoint_spring = hip.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        neckJoint_spring = hip.transform.GetChild(0).GetChild(1).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        l_HipJoint_spring = hip.transform.GetChild(1).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        l_KneeJoint_spring = hip.transform.GetChild(1).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        l_FootJoint_spring = hip.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        r_HipJoint_spring = hip.transform.GetChild(2).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring; ;
        r_KneeJoint_spring = hip.transform.GetChild(2).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        r_FootJoint_spring = hip.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        tailJoint_spring = hip.transform.GetChild(3).GetComponent<ConfigurableJoint>().angularXDrive.positionSpring;
        #endregion
    }

    void Update()
    {
        this.targetAnimator.SetBool("Walk", this.walk);
        this.targetAnimator.SetBool("In Air", this.inAir);

        movement = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y).normalized;
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
        move.y = 0f;

        if(Physics.Raycast(hip.transform.position, rayDownDir, out rayDownHit, rayDownLength, ~playerLayerMask))
        {
            Debug.Log("hitsomething");

            if (rayDownHit.collider)
            {
                isGrounded = true;

                if (jumpControl.action.triggered)
                {
                    Debug.Log("jump");
                    this.hip.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                    targetAnimator.SetTrigger("Jump");
                    isGrounded = false;
                }
            }
        }
        else
        {
            isGrounded = false;
        }

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

            if (isGrounded)
            {
                this.walk = true;
            }
        }
        else
        {
            this.walk = false;
        }

        switch (isGrounded)
        {
            case true:

                this.inAir = false;

                if (hip.velocity.magnitude > groundSpeedCap)
                {
                    hip.velocity = Vector3.ClampMagnitude(hip.velocity, groundSpeedCap);
                    Debug.Log("Clamped Ground Speed");
                }

                break;

            case false:

                hip.velocity = Vector3.ClampMagnitude(hip.velocity, velocityCap);
                Debug.Log("Clamped Overall Speed");

                this.walk = false;
                this.inAir = true;

                if(hip.velocity.y < -10)
                {
                    Debug.Log("Free Falling!");
                    Ragdoll(true, 25);
                }

                break;
        }
    }

    public void Ragdoll(bool activated, float posJointConfig)
    {
        JointDrive jointDrive = hipJoint.angularXDrive;
        jointDrive.positionSpring = posJointConfig;

        if (activated)
        {
            hipJoint.angularXDrive = jointDrive;
            hipJoint.angularYZDrive = jointDrive;

            foreach(ConfigurableJoint joint in hip.transform.GetComponentsInChildren<ConfigurableJoint>())
            {
                joint.angularXDrive = jointDrive;
                joint.angularYZDrive = jointDrive;
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
