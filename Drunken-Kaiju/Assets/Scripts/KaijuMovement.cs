using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KaijuMovement : MonoBehaviour
{
    public static KaijuMovement singleton;

    #region Rigidbody Setup
    Rigidbody rb; //Overall Rigidbody for Parent Object
    [SerializeField] Rigidbody rootRb; //Root Rigidbody (recommended)
    #endregion

    //New Input System References
    #region Controller Input Actions
    [Header("Input Action References")]
    public InputActionReference movementControl;
    public InputActionReference jumpControl;
    public InputActionReference dashControl;
    public InputActionReference attackControl;
    public InputActionReference pukeControl;
    public InputActionReference pickup_throwControl;
    #endregion

    //Different Camera States
    #region Camera Stuff
    private Transform cameraMainTransform;

    #endregion

    //Values
    #region Values
    [Header("Values and Animator Manager")]
    [Range(0,100)] public float health;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] float dashDistance;
    [SerializeField] float dashHeight;
    float attackTimer;
    [Range(0, 100)] public float pukeAmount;
    [SerializeField] float pukeDepleteSpeed; //Will dictate how long puking last
    [SerializeField] float ragdollActivateSpeed;
    [HideInInspector] public ParticleSystem pukeFX;
    #endregion

    #region Pickup/Throwing variables
    Transform objectHolderTransform;
    GameObject heldObj;
    bool isHolding;
    [SerializeField] float throwPower;

    float dragStore;
    #endregion

    //A list for both Config Joints and Spring Position Values
    #region Joint Setup
    ConfigurableJoint[] playerJoints = new ConfigurableJoint[14];
    float[] playerJointSprings = new float[14];
    #endregion

    //Animator Bools and Setup
    #region Animation Setup
    [SerializeField] Animator targetAnimator; //Jim Animator
    bool walk = false;
    bool inAir = false;
    bool isAttacking = false;
    #endregion

    #region Velocity Caps
    [Header("Physics and Raycast Manager")]
    [Range(1, 60)] [SerializeField] float velocityCap;
    [Range(1, 4)] [SerializeField] float groundSpeedCap;
    #endregion

    #region Movement Vectors
    Vector2 movement;
    Vector3 move;
    #endregion

    #region Raycast Setup
    Vector3 rayForwardDir; //raycast vector that places the raycast's position
    [SerializeField] float rayForwardLength; //length of raycast
    RaycastHit rayForwardHit; //raycast collider

    Vector3 rayDownDir;
    [SerializeField] float rayDownLength;
    RaycastHit rayDownHit;

    LayerMask playerLayerMask = 1 << 6;
    #endregion

    //Specific bools for player functions
    #region Bool States
    bool activateRagdoll;
    bool dashAttack;
    bool isGrounded;
    bool isPuking;
    #endregion


    void Awake()
    {
        singleton = this;
        rayForwardDir = rootRb.transform.TransformVector(rootRb.gameObject.transform.forward);
        rayDownDir = rootRb.transform.TransformVector(-rootRb.gameObject.transform.up);
    }

    void Start()
    {
        health = 100;
        rb = gameObject.GetComponent<Rigidbody>();
        cameraMainTransform = GameObject.Find("Main Camera").transform;

        activateRagdoll = false;

        rootRb.gameObject.GetComponent<CopyLimbs>().canCopy = true;

        objectHolderTransform = rootRb.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform;

        pukeFX = rootRb.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<ParticleSystem>();

        heldObj = null;

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
        #region Animation Bool Assign
        this.targetAnimator.SetBool("Walk", this.walk);
        this.targetAnimator.SetBool("In Air", this.inAir);
        this.targetAnimator.SetBool("Is Attacking", this.isAttacking);
        this.targetAnimator.SetBool("Ragdoll", this.activateRagdoll);
        this.targetAnimator.SetBool("Dive", this.dashAttack);
        this.targetAnimator.SetBool("Is Puking", this.isPuking);
        #endregion

        //Input Activation must remain on top
        #region Specific Bool related Control Activations
        switch (activateRagdoll)
        {
            case true:

                movementControl.action.Disable();
                dashControl.action.Disable();
                attackControl.action.Disable();
                pukeControl.action.Disable();
                pickup_throwControl.action.Disable();
                break;

            case false:

                movementControl.action.Enable();
                dashControl.action.Enable();
                attackControl.action.Enable();
                pukeControl.action.Enable();
                pickup_throwControl.action.Enable();
                break;
        }

        switch (isGrounded)
        {
            case true:
                attackControl.action.Enable();
                break;
            case false:
                attackControl.action.Disable();
                break;
        }

        switch (isPuking)
        {
            case true:
                movementControl.action.Disable();
                jumpControl.action.Disable();
                dashControl.action.Disable();
                attackControl.action.Disable();
                pukeControl.action.Disable();
                pickup_throwControl.action.Disable();
                break;
            case false:
                movementControl.action.Enable();
                jumpControl.action.Enable();
                dashControl.action.Enable();
                attackControl.action.Enable();
                pukeControl.action.Enable();
                pickup_throwControl.action.Enable();
                break;
        }
        #endregion

        //Value Management must remain on top due to input activation
        #region Value Management
        if (attackTimer > 0)
        {
            movementControl.action.Disable();
            jumpControl.action.Disable();
            dashControl.action.Disable();
            pukeControl.action.Disable();
            pickup_throwControl.action.Disable();
            isAttacking = true;
            attackTimer -= Time.deltaTime;
        }
        else if(attackTimer <= 0)
        {
            attackTimer = 0;
            movementControl.action.Enable();
            jumpControl.action.Enable();
            dashControl.action.Enable();
            pukeControl.action.Enable();
            pickup_throwControl.action.Enable();
            isAttacking = false;
        }

        if (pukeAmount > 100)
        {
            pukeAmount = 100;
        }
        else if (pukeAmount < 0)
        {
            pukeAmount = 0;
        }

        if (isPuking && pukeAmount > 0)
        {
            pukeAmount -= pukeDepleteSpeed * Time.deltaTime;
        }
        else if (pukeAmount <= 0 && isPuking)
        {
            pukeAmount = 0;
            pukeFX.Stop();
            activateRagdoll = true;
            ActivateRagdoll(activateRagdoll);
            isPuking = false;
        }
        #endregion

        if(health > 100)
        {
            health = 100;
        }
        else if(health < 0)
        {
            health = 0;
        }

        movement = movementControl.action.ReadValue<Vector2>();
        move = new Vector3(movement.x, 0, movement.y).normalized;
        if (!dashAttack)
        {
            move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x;
            move.y = 0f;
        }
        if (Physics.Raycast(rootRb.transform.position, rayDownDir, out rayDownHit, rayDownLength, ~playerLayerMask))
        {
            if (rayDownHit.collider.tag != "Interactable")
            {
                Debug.Log("hitsomething");

                if (rayDownHit.collider && !activateRagdoll)
                {
                    isGrounded = true;

                    if (attackTimer == 0)
                    {
                        if (jumpControl.action.triggered && !activateRagdoll)
                        {
                            Debug.Log("jump");
                            this.rootRb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
                            targetAnimator.SetTrigger("Jump");
                            isGrounded = false;
                        }
                    }
                }
            }
        }
        else
        {
            isGrounded = false;
        }

        rayForwardDir = rootRb.transform.forward.normalized;

        rayDownDir = -rootRb.transform.up.normalized;

        Debug.DrawRay(rootRb.transform.position, rayForwardDir * rayForwardLength, Color.red); //raycast debug
        Debug.DrawRay(rootRb.transform.position, rayDownDir * rayDownLength, Color.red); //raycast debug



        if (movement.magnitude != 0)
        {
            rootRb.gameObject.GetComponent<CopyLimbs>().canCopy = true;
        }
        else if (movement.magnitude == 0 && isGrounded || isAttacking == true || isPuking == true || !isGrounded)
        {
            rootRb.gameObject.GetComponent<CopyLimbs>().canCopy = false;
        }


        if (jumpControl.action.triggered && activateRagdoll) //Resets player after ragdolled
        {
            if (rootRb.velocity.magnitude < 0.2)
            {
                activateRagdoll = false;
                ActivateRagdoll(activateRagdoll);
            }
        }

        if (attackTimer == 0)
        {
            if (dashControl.action.triggered)
            {
                rootRb.AddForce(rootRb.transform.forward.x * dashDistance, dashHeight, rootRb.transform.forward.z * dashDistance, ForceMode.Impulse);
                activateRagdoll = true;
                ActivateRagdoll(activateRagdoll);
                dashAttack = true;

                if (isHolding)
                {
                    ObjectPickupManager(heldObj.GetComponent<Rigidbody>());
                }
            }
        }

        if (attackControl.action.triggered && isGrounded)
        {
            targetAnimator.SetTrigger("Attack");

            if (targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("L_PUNCH") || targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("R_PUNCH") || targetAnimator.GetCurrentAnimatorStateInfo(0).IsName("L_PUNCH_WALK"))
            {
                attackTimer = targetAnimator.GetCurrentAnimatorStateInfo(0).length;
            }


            if (Physics.Raycast(rootRb.transform.position, rayForwardDir, out rayForwardHit, rayForwardLength, ~playerLayerMask))
            {
                //Check if either punch left or punch right is playing and then check the frames that are active
            }

            if (isHolding)
            {
                ObjectPickupManager(heldObj.GetComponent<Rigidbody>());
            }
        }

        if (pukeControl.action.triggered && isGrounded && pukeAmount == 100)
        {
            isPuking = true;
            //Insert Animation
            pukeFX.Play();
            if (isHolding)
            {
                ObjectPickupManager(heldObj.GetComponent<Rigidbody>());
            }
        }

        if (pickup_throwControl.action.triggered)
        {
            if (!isHolding)
            {
                if (Physics.Raycast(rootRb.transform.position, rayForwardDir, out rayForwardHit, rayForwardLength, ~playerLayerMask))
                {
                    if (rayForwardHit.collider.tag == "Interactable")
                    {
                        if (rayForwardHit.collider.gameObject.GetComponent<Rigidbody>())
                        {
                            ObjectPickupManager(rayForwardHit.collider.gameObject.GetComponent<Rigidbody>());
                        }

                        if (rayForwardHit.collider.gameObject.GetComponent<PickupObjects>())
                        {
                            if(rayForwardHit.collider.gameObject.GetComponent<PickupObjects>().pickupTypes == PickupObjects.PickupTypes.bottlePickup && !rayForwardHit.collider.gameObject.GetComponent<PickupObjects>().hasDrank)
                            {
                                rayForwardHit.collider.gameObject.GetComponent<PickupObjects>().BottlePickup();
                            }
                        }
                    }
                }
            }
            else
            {
                ObjectPickupManager(heldObj.GetComponent<Rigidbody>(), true);
            }
        }

        if (isHolding)
        {
            heldObj.transform.position = objectHolderTransform.transform.position;
            //Physics.IgnoreLayerCollision(6, 8, true);
        }
        else if (!isHolding)
        {
            //Physics.IgnoreLayerCollision(6, 8, false);
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

                if (rootRb.velocity.y < ragdollActivateSpeed)
                {
                    activateRagdoll = true;
                    Debug.Log("Free Falling!");
                    ActivateRagdoll(activateRagdoll);
                }

                break;
        }
    }

    #region ActivateRagdoll
    public void ActivateRagdoll(bool activated)
    {
        //The Universal Joint Drive's spring Position amount for when the player enters a Ragdoll state
        JointDrive deactiveRagdollDrive = playerJoints[0].angularXDrive;
        deactiveRagdollDrive.positionSpring = 35;

        //This setups each JointDrive Variable to equal the stored float of each joint's spring position
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

        #region Activation States
        if (activated) //Sets all the spring positions to equal [JointDrive deactivateRagdollDrive]
        {
            foreach (ConfigurableJoint joint in playerJoints)
            {
                joint.angularXDrive = deactiveRagdollDrive;
                joint.angularYZDrive = deactiveRagdollDrive;
            }
        }
        else //Restores all values back to normal
        {
            foreach (ConfigurableJoint joint in playerJoints)
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

            rootRb.transform.position += new Vector3(0, 1, 0);
        }
        #endregion

        #region Bool Status
        if (dashAttack)
        {
            dashAttack = false;
        }
        #endregion
    }
    #endregion

    void ObjectPickupManager(Rigidbody objRb, bool hasThrown = false)
    {
        if (heldObj == null)
        {
            targetAnimator.SetTrigger("Grab");
            dragStore = objRb.drag;
            heldObj = rayForwardHit.collider.gameObject;
            Debug.Log("Pickup " + heldObj.name);
            objRb.useGravity = false;
            objRb.isKinematic = true;
            objRb.drag = 10;
            isHolding = true;
            objRb.transform.rotation = new Quaternion(0, 0, 0, 0);

            if(heldObj.layer != 8)
            {
                heldObj.layer = 8;
            }
        }
        else if (heldObj != null)
        {
            objRb.drag = dragStore;
            objRb.isKinematic = false;
            objRb.useGravity = true;
            isHolding = false;

            if (heldObj.layer == 8)
            {
                heldObj.layer = 0;
            }

            if (hasThrown)
            {
                targetAnimator.SetTrigger("Throw");
                objRb.AddForce(rootRb.transform.forward.x * throwPower, (throwPower/3), rootRb.transform.forward.z * throwPower, ForceMode.Impulse);
            }

            heldObj = null;
            //Debug.Log("Object Dropped. heldObj variable is currently " + heldObj.name);

        }
    }

    #region Input Enable / Disable stuff
    private void OnEnable()
    {
        movementControl.action.Enable();
        jumpControl.action.Enable();
        dashControl.action.Enable();
        attackControl.action.Enable();
        pukeControl.action.Enable();
        pickup_throwControl.action.Enable();
    }

    private void OnDisable()
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();
        dashControl.action.Disable();
        attackControl.action.Disable();
        pukeControl.action.Disable();
        pickup_throwControl.action.Disable();
    }
    #endregion
}