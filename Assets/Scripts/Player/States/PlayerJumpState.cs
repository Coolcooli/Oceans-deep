using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement)
    {
        IsRootState = true;
    }

    public override void EnterState()
    {
        if (Movement.IsJumpPressed && Movement.IsGrounded)
        {
            Movement.Velocity = new Vector3(0, Movement.JumpForce, 0); // Add the jump force to the velocity
            Movement.IsJumpPressed = false;
        }
    }

    public override void UpdateState()
    {
        HandleGravity();
    }

    public override void CheckSwitchStates()
    {
        if (Movement.IsGrounded)
            SwitchState(Factory.Grounded());
        if (Context.IsInWater)
            SwitchState(Factory.InWater());
    }

    private void HandleGravity()
    {
        // Apply gravity to the context
        Movement.Velocity -= new Vector3(0, Movement.Gravity, 0) * Time.deltaTime;
    }
}