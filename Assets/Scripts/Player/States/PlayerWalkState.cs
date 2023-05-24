using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    private bool startedInWater = false;

    public PlayerWalkState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { }

    public override void EnterState()
    {
        if (!Context.IsInWater)
        {
            Context.WalkSound.StartLoop("movementSound");
            Context.WalkSound.Sound.pitch = 1.2f;
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
        }
        if (!Context.IsInWater && startedInWater)
        {
            Context.WalkSound.StartLoop("movementSound");
        }
    }

    public override void CheckSwitchStates()
    {
        if (!Movement.IsMoving)
            SwitchState(Factory.Idle());
        if (Movement.IsSprinting)
            SwitchState(Factory.Sprint());
    }

    public override void ExitState()
    {
        if (!Context.IsInWater)
            Context.WalkSound.StopLoop("movementSound");
    }
}
