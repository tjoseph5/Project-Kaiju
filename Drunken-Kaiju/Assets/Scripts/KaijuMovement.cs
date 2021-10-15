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


    #region Joint Setup
    ConfigurableJoint [] playerJoints = new ConfigurableJoint [14];
    float [] playerJointSprings = new float [14];
    #endregion

    [SerializeField] Rigidbody rootRb;

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

    bool activateRagdoll;


    void Awake()
    {
        rayForwardDir = rootRb.transform.TransformVector(rootRb.gameObject.transform.forward);
        rayDownDir = rootRb.transform.TransformVector(-rootRb.gameObject.transform.up);
    }

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        cameraMainTransform = GameObject.Find("Main Camera").transform;

        activateRagdoll = false;

        #region Config Joint Setup

        playerJoints[0] = rootRb.transform.GetComponent<ConfigurableJoint>();                                       //Root Joint
        playerJoints[1] = rootRb.transform.GetChild(0).GetComponent<ConfigurableJoint>();                           //Chest Joint
        playerJoints[2] = rootRb.transform.GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>();               //Left Shoulder Joint
        playerJoints[3] = rootRb.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>();   //Left Elbow Joint
        playerJoints[4] = rootRb.transform.GetChild(0).GetChild(1).GetComponent<ConfigurableJoint>();               //Neck Joint
        playerJoints[5] = rootRb.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ConfigurableJoint>();   //Right Shoulder Joint
        playerJoints[6] = rootRb.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<ConfigurableJoint>();   //Right Elbow Joint
        playerJoints[7] = rootRb.transform.GetChild(1).GetComponent<ConfigurableJoint>();                           //Left Hip Joint
        playerJoints[8] = rootRb.transform.GetChild(1).GetChild(0).GetComponent<ConfigurableJoint>();               //Left Knee Joint
        playerJoints[9] = rootRb.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>();   //Left Foot Joint
        playerJoints[10] = rootRb.transform.GetChild(2).GetComponent<ConfigurableJoint>();                          //Right Hip Joint
        playerJoints[11] = rootRb.transform.GetChild(2).GetChild(0).GetComponent<ConfigurableJoint>();              //Right Knee Joint
        playerJoints[12] = rootRb.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<ConfigurableJoint>();  //Right Foot Joint
        playerJoints[13] = rootRb.transform.GetChild(3).GetComponent<ConfigurableJoint>();                          //Tail Joint

        #endregion
        #region Config Joint Spring Position Store Setup

        playerJointSprings[0] = playerJoints[0].angularXDrive.positionSpring;   //Root Spring
        playerJointSprings[1] = playerJoints[1].angularXDrive.positionSpring;   //Chest Spring
        playerJointSprings[2] = playerJoints[2].angularXDrive.positionSpring;   //Left Shoulder Spring
        playerJointSprings[3] = playerJoints[3].angularXDrive.positionSpring;   //Left Elbow Spring
        playerJointSprings[4] = playerJoints[4].angularXDrive.positionSpring;   //Neck Spring
        playerJointSprings[5] = playerJoints[5].angularXDrive.positionSpring;   //Right Shoulder Spring
        playerJointSprings[6] = playerJoints[6].angularXDrive.positionSpring;   //Right Elbow Spring
        playerJointSprings[7] = playerJoints[7].angularXDrive.positionSpring;   //Left Hip Spring
        playerJointSprings[8] = playerJoints[8].angularXDrive.positionSpring;   //Left Knee Spring
        playerJointSprings[9] = playerJoints[9].angularXDrive.positionSpring;   //Left Foot Spring
        playerJointSprings[10] = playerJoints[10].angularXDrive.positionSpring;  //Right Hip Spring
        playerJointSprings[11] = playerJoints[11].angularXDrive.positionSpring;  //Right Knee Spring
        playerJointSprings[12] = playerJoints[12].angularXDrive.positionSpring;  //Right Foot Spring
        playerJointSprings[13] = playerJoints[13].angularXDrive.positionSpring;  //Tail Spring

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

        if(Physics.Raycast(rootRb.transform.position, rayDownDir, out rayDownHit, rayDownLength, ~playerLayerMask))
        {
            Debug.Log("hitsomething");

            if (rayDownHit.collider)
            {
                isGrounded = true;

                if (jumpControl.action.triggered)
                {
                    Debug.Log("jump");
                    this.rootRb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
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
            rayForwardDir = rootRb.transform.forward.normalized;
        }

        rayDownDir = -rootRb.transform.up.normalized;

        Debug.DrawRay(rootRb.transform.position, rayForwardDir * rayForwardLength, Color.red); //raycast debug
        Debug.DrawRay(rootRb.transform.position, rayDownDir * rayDownLength, Color.red); //raycast debug

        if(jumpControl.action.triggered && activateRagdoll)
        {
            activateRagdoll = false;
            ActivateRagdoll(activateRagdoll);
        }
    }

    void FixedUpdate()
    {
        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.z, move.x) * Mathf.Rad2Deg;

            this.playerJoints[0].targetRotation = Quaternion.Euler(0f, targetAngle + 90, 0f);

            this.rootRb.AddForce(move * this.speed);

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

                if (rootRb.velocity.magnitude > groundSpeedCap)
                {
                    rootRb.velocity = Vector3.ClampMagnitude(rootRb.velocity, groundSpeedCap);
                    Debug.Log("Clamped Ground Speed");
                }

                break;

            case false:

                rootRb.velocity = Vector3.ClampMagnitude(rootRb.velocity, velocityCap);
                Debug.Log("Clamped Overall Speed");

                this.walk = false;
                this.inAir = true;

                if(rootRb.velocity.y < -10)
                {
                    activateRagdoll = true;
                    Debug.Log("Free Falling!");
                    ActivateRagdoll(activateRagdoll);
                }

                break;
        }
    }

    public void ActivateRagdoll(bool activated)
    {
        JointDrive deactiveRagdollDrive = playerJoints[0].angularXDrive;
        deactiveRagdollDrive.positionSpring = 25;

        #region Joint Drive Setup

        JointDrive rootDrive = playerJoints[0].angularXDrive;
        rootDrive.positionSpring = playerJointSprings[0];

        JointDrive chestDrive = playerJoints[1].angularXDrive;
        chestDrive.positionSpring = playerJointSprings[1];

        JointDrive l_ShoulderDrive = playerJoints[2].angularXDrive;
        l_ShoulderDrive.positionSpring = playerJointSprings[2];

        JointDrive l_ElbowDrive = playerJoints[3].angularXDrive;
        l_ElbowDrive.positionSpring = playerJointSprings[3];

        JointDrive neckDrive = playerJoints[4].angularXDrive;
        neckDrive.positionSpring = playerJointSprings[4];

        JointDrive r_ShoulderDrive = playerJoints[5].angularXDrive;
        r_ShoulderDrive.positionSpring = playerJointSprings[5];

        JointDrive r_ElbowDrive = playerJoints[6].angularXDrive;
        r_ElbowDrive.positionSpring = playerJointSprings[6];

        JointDrive l_HipDrive = playerJoints[7].angularXDrive;
        l_HipDrive.positionSpring = playerJointSprings[7];

        JointDrive l_KneeDrive = playerJoints[8].angularXDrive;
        l_KneeDrive.positionSpring = playerJointSprings[8];

        JointDrive l_FootDrive = playerJoints[9].angularXDrive;
        l_FootDrive.positionSpring = playerJointSprings[9];

        JointDrive r_HipDrive = playerJoints[10].angularXDrive;
        r_HipDrive.positionSpring = playerJointSprings[10];

        JointDrive r_KneeDrive = playerJoints[11].angularXDrive;
        r_KneeDrive.positionSpring = playerJointSprings[11];

        JointDrive r_FootDrive = playerJoints[12].angularXDrive;
        r_FootDrive.positionSpring = playerJointSprings[12];

        JointDrive tailDrive = playerJoints[13].angularXDrive;
        tailDrive.positionSpring = playerJointSprings[13];

        #endregion

        if (activated)
        {
            foreach(ConfigurableJoint joint in playerJoints)
            {
                joint.angularXDrive = deactiveRagdollDrive;
                joint.angularYZDrive = deactiveRagdollDrive;
            }
            movementControl.action.Disable();
        }
        else
        {
            foreach(ConfigurableJoint joint in playerJoints)
            {
                joint.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }

            #region Spring Float Assigner
            playerJoints[0].angularXDrive = rootDrive;
            playerJoints[0].angularYZDrive = rootDrive;

            playerJoints[1].angularXDrive = chestDrive;
            playerJoints[1].angularYZDrive = chestDrive;

            playerJoints[2].angularXDrive = l_ShoulderDrive;
            playerJoints[2].angularYZDrive = l_ShoulderDrive;

            playerJoints[3].angularXDrive = l_ElbowDrive;
            playerJoints[3].angularYZDrive = l_ElbowDrive;

            playerJoints[4].angularXDrive = neckDrive;
            playerJoints[4].angularYZDrive = neckDrive;

            playerJoints[5].angularXDrive = r_ShoulderDrive;
            playerJoints[5].angularYZDrive = r_ShoulderDrive;

            playerJoints[6].angularXDrive = r_ElbowDrive;
            playerJoints[6].angularYZDrive = r_ElbowDrive;

            playerJoints[7].angularXDrive = l_HipDrive;
            playerJoints[7].angularYZDrive = l_HipDrive;

            playerJoints[8].angularXDrive = l_KneeDrive;
            playerJoints[8].angularYZDrive = l_KneeDrive;

            playerJoints[9].angularXDrive = l_FootDrive;
            playerJoints[9].angularYZDrive = l_FootDrive;

            playerJoints[10].angularXDrive = r_HipDrive;
            playerJoints[10].angularYZDrive = r_HipDrive;

            playerJoints[11].angularXDrive = r_KneeDrive;
            playerJoints[11].angularYZDrive = r_KneeDrive;

            playerJoints[12].angularXDrive = r_FootDrive;
            playerJoints[12].angularYZDrive = r_FootDrive;

            playerJoints[13].angularXDrive = tailDrive;
            playerJoints[13].angularYZDrive = tailDrive;
            #endregion

            movementControl.action.Enable();
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
