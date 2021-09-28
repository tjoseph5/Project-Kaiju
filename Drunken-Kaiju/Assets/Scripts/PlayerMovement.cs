using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;
    public Rigidbody hips;
    public bool isGrounded;

    Vector2 movement;
    Vector3 move;

    #region Controller Input Actions
    public InputActionReference movementControl;
    public InputActionReference jumpControl;
    #endregion

    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y).normalized;

        Debug.Log(move);
    }

    private void FixedUpdate()
    {
        if (move.magnitude >= 0.1f)
        {
            this.hips.AddForce(move * this.speed);
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
