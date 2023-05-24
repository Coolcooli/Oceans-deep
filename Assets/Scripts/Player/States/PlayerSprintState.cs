using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    private const float SPRINTMULTIPLIER = 1.5f;

    private bool startedInWater = false;
    public PlayerSprintState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { }

    public override void EnterState()
    {
        Movement.SprintMultiplier = SPRINTMULTIPLIER;

        if (!Context.IsInWater)
        {
            Context.WalkSound.StartLoop("movementSound");
            Context.WalkSound.Sound.pitch = 1.7f;
            startedInWater = false;
        }
        else
            startedInWater = true;
    }

    public override void UpdateState()
    {
        if (Context.IsInWater && !startedInWater)
        {
            Context.WalkSound.StopLoop("movementSound");
            Context.WalkSound.Sound.pitch = 1f;
        }
        if (!Context.IsInWater && startedInWater)
        {
            Context.WalkSound.StartLoop("movementSound");
            Context.WalkSound.Sound.pitch = SPRINTMULTIPLIER;
        }
    }

    public override void CheckSwitchStates()
    {
        if (!Movement.IsMoving)
            SwitchState(Factory.Idle());
        if (!Movement.IsSprinting)
            SwitchState(Factory.Walk());
    }

    public override void ExitState()
    {
        Movement.SprintMultiplier = 1f;

        if (!Context.IsInWater)
        {
            Context.WalkSound.StopLoop("movementSound");
        }
    }
}
