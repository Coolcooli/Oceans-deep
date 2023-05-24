using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloatingState : PlayerBaseState
{
    public PlayerFloatingState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { IsRootState = true; }

    private float speed = 5.0f;
    private float amplitude = .005f;

    public override void EnterState()
    {
        Context.IsInWater = true;
    }

    public override void UpdateState()
    {
        if (Movement.IsJumpPressed)
        {
            Movement.Velocity = Vector3.up * Movement.WaterSpeed;
        }
        else if (Movement.IsCrouchPressed)
        {
            Movement.Velocity = Vector3.up * -Movement.WaterSpeed;
        }
        else
        {
            if (Movement.MovementDirection.magnitude <= 0)
                Movement.transform.position += new Vector3(0, Mathf.Sin(Time.time * speed) * amplitude, 0);

            Movement.Velocity = Vector3.zero;
        }
    }

    public override void CheckSwitchStates()
    {
        if (Context.CurrentWaterColliders <= 0)
            SwitchState(Factory.Jump());
        if (Context.CurrentAirColliders <= 0)
            SwitchState(Factory.InWater());
    }

    public override void InitializeSubState()
    {
        if (Movement.IsMoving)
            SetSubState(Factory.Walk());
        else
            SetSubState(Factory.Idle());
    }
}
