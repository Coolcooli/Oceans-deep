public class PlayerStateFactory
{
    private Player context;
    private PlayerMovement movement;

    public PlayerStateFactory(Player context, PlayerMovement movement)
    {
        this.context = context;
        this.movement = movement;
    }

    // Create a factory by making functions for all states
    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(context, this, movement);
    }
    public PlayerBaseState Walk()
    {
        return new PlayerWalkState(context, this, movement);
    }
    public PlayerBaseState Sprint()
    {
        return new PlayerSprintState(context, this, movement);
    }
    public PlayerBaseState Jump()
    {
        return new PlayerJumpState(context, this, movement);
    }
    public PlayerBaseState InWater()
    {
        return new PlayerInWaterState(context, this, movement);
    }
    public PlayerBaseState Grounded()
    {
        return new PlayerGroundedState(context, this, movement);
    }
    public PlayerBaseState Floating()
    {
        return new PlayerFloatingState(context, this, movement);
    }
}