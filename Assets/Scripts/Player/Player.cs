using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerBaseState currentState;
    public PlayerBaseState CurrentState { get { return currentState; } set { currentState = value; } }

    private PlayerStateFactory states;

    [SerializeField]
    private bool isInWater = true;
    public bool IsInWater { get { return isInWater; } set { isInWater = value; } }
    private int currentAirColliders;
    public int CurrentAirColliders => currentAirColliders;
    private int currentWaterColliders;
    public int CurrentWaterColliders => currentWaterColliders;

    private SoundManager walkSound;
    public SoundManager WalkSound => walkSound;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        walkSound = GetComponent<SoundManager>();
    }

    private void Start()
    {
        PlayerMovement movement = GetComponent<PlayerMovement>();
        states = new PlayerStateFactory(this, movement);
        currentState = movement.IsGrounded ? states.Grounded() : states.Jump();
        currentState.EnterState();
    }

    void Update()
    {
        currentState.UpdateStates();
    }

    /// <summary>
    /// Checks if the player in entering air
    /// </summary>
    /// <param name="other">The object that the player collides with</param>
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Air":
                if (currentWaterColliders > 0)
                {
                    currentAirColliders++;
                    isInWater = true;
                    currentState.SwitchState(currentState.Factory.Floating());
                    break;
                }
                isInWater = false;
                currentAirColliders++;
                break;
            case "Water":
                currentWaterColliders++;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Air":
                currentAirColliders--;
                if (currentAirColliders <= 0)
                    isInWater = true;
                break;
            case "Water":
                currentWaterColliders--;
                break;
        }
    }
}