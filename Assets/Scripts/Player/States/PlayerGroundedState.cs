using UnityEngine;

public class PlayerGroundedState : PlayerBaseState
{
    private int groundedGravity = -5;

    public PlayerGroundedState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void EnterState()
    {
        // Apply a constant gravity to 'stick' to the ground when the terrain is uneven
        Movement.Velocity = new Vector3(0, groundedGravity, 0);
    }

    public override void CheckSwitchStates()
    {
        if (Movement.IsJumpPressed || !Movement.IsGrounded)
            SwitchState(Factory.Jump());
        if (Context.IsInWater)
            SwitchState(Factory.InWater());
    }

    public override void InitializeSubState()
    {
        if (Movement.IsMoving)
            SetSubState(Factory.Walk());
        else
            SetSubState(Factory.Idle());
    }

    public override void ExitState()
    {
        Movement.Velocity = Vector3.zero;
    }
}
