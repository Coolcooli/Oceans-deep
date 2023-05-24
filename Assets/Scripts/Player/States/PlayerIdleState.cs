using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { }

    public override void CheckSwitchStates()
    {
        if (Movement.IsMoving)
        {
            if (Movement.IsSprinting)
                SwitchState(Factory.Sprint());
            else
                SwitchState(Factory.Walk());
        }
    }
}
