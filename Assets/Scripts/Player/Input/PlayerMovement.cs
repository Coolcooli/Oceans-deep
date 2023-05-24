using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;

    private bool isMoving = false;
    public bool IsMoving => isMoving;
    private bool isSprinting = false;
    private float sprintMultiplier = 1f;
    public float SprintMultiplier { set { sprintMultiplier = value; } }
    public bool IsSprinting => isSprinting;
    private bool isJumpPressed;
    public bool IsJumpPressed { get { return isJumpPressed; } set { isJumpPressed = value; } }
    private bool isCrouchPressed;
    public bool IsCrouchPressed => isCrouchPressed;

    [SerializeField]
    private float jumpForce = 10;
    public float JumpForce => jumpForce;

    private Vector3 movementDirection;
    public Vector3 MovementDirection { get { return movementDirection; } set { movementDirection = value; } }

    private Vector3 velocity;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }
    public float Gravity { get { return 30f; } }
    public bool IsGrounded => characterController.isGrounded;

    [SerializeField] private float deceleration = 1f;
    [SerializeField]
    private float landSpeed = 5;
    [SerializeField] private float landAcceleration = .05f;
    [SerializeField]
    private float waterSpeed = 3;
    public float WaterSpeed { get { return waterSpeed; } }
    [SerializeField] private float waterAcceleration = .02f;
    public float WaterAcceleration => waterAcceleration;

    private Camera playerCamera;
    private Player player;

    private Vector3 currentMovement;

    [SerializeField]
    private bool freeze = true;
    public bool Freeze { get { return freeze; } set { freeze = value; } }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<Player>();
        playerCamera = Camera.main;
    }

    private void Update()
    {
        currentMovement = ConvertMoveDirection();

        if(!freeze)
        {
            characterController.Move(currentMovement * Time.deltaTime);
            characterController.Move(velocity * Time.deltaTime);
        }
    }

    /// <summary>
    /// Applies input from jump key
    /// </summary>
    /// <param name="context">Value jump key</param>
    public void OnJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
    }

    /// <summary>
    /// Applies input from jump key
    /// </summary>
    /// <param name="context">Value jump key</param>
    public void OnCrouch(InputAction.CallbackContext context)
    {
        isCrouchPressed = context.ReadValueAsButton();
    }

    /// <summary>
    /// Apply movement from the keys
    /// </summary>
    /// <param name="context">Vector2 that contains input</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if (input.magnitude > 0)
            isMoving = true;
        else
            isMoving = false;

        movementDirection = new Vector3(input.x, 0, input.y);
    }

    /// <summary>
    /// Apply input from sprint key
    /// </summary>
    /// <param name="context"></param>
    public void OnSprint(InputAction.CallbackContext context)
    {
        isSprinting = context.ReadValueAsButton();
    }

    /// <summary>
    /// Returns movement vector based on if the player is inside the water
    /// </summary>
    private Vector3 ConvertMoveDirection()
    {
        if (movementDirection.magnitude <= 0)
        {
            return Mathf.Lerp(currentMovement.magnitude, 0, deceleration) * playerCamera.transform.forward;
        }
        if (player.IsInWater)
        {
            Vector3 movement = sprintMultiplier * waterSpeed * (movementDirection.x * transform.right + movementDirection.z * playerCamera.transform.forward);
            float wantedSpeed = Mathf.Lerp(currentMovement.magnitude, movement.magnitude, waterAcceleration);
            return movement.normalized * wantedSpeed;
        }
        else
        {
            Vector3 movement = landSpeed * sprintMultiplier * (movementDirection.x * transform.right + movementDirection.z * transform.forward);
            float wantedSpeed = Mathf.Lerp(currentMovement.magnitude, movement.magnitude, landAcceleration);
            return wantedSpeed * movement.normalized;
        }
    }
}
