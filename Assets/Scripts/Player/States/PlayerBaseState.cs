using UnityEngine;

public abstract class PlayerBaseState
{
    private bool isRootState = false;
    private Player context;
    private PlayerMovement movement;
    private PlayerStateFactory factory;
    private PlayerBaseState currentSuperState;
    private PlayerBaseState currentSubState;

    protected bool IsRootState { set { isRootState = value; } }
    protected Player Context { get { return context; } }
    protected PlayerMovement Movement { get { return movement; } }
    public PlayerStateFactory Factory { get { return factory; } }

    public PlayerBaseState(Player context, PlayerStateFactory factory, PlayerMovement movement)
    {
        this.context = context;
        this.factory = factory;
        this.movement = movement;
    }

    /// <summary>
    /// Handles logic from derived class when entering a new state
    /// </summary>
    public virtual void EnterState() { }

    /// <summary>
    /// Updates the current state with implementation from the derived classes
    /// </summary>
    public virtual void UpdateState() { }

    /// <summary>
    /// Checks if the current state should be switched, each derived class has it's own implementation
    /// </summary>
    public virtual void CheckSwitchStates() { }

    /// <summary>
    /// Handles logic from derived class when exiting current state
    /// </summary>
    public virtual void ExitState() { }

    /// <summary>
    /// Initializes sub state(s) for current state
    /// </summary>
    public virtual void InitializeSubState() { }

    /// <summary>
    /// Handles all updates. Only this function is called in the update in the context
    /// </summary>
    public void UpdateStates()
    {
        UpdateState();
        CheckSwitchStates();
        UpdateSubState();
    }

    /// <summary>
    /// Handles switching states, handles exit and enter state, rootstate and superstate
    /// </summary>
    /// <param name="newState">The new state that is wanted</param>
    public void SwitchState(PlayerBaseState newState)
    {
        ExitState();

        newState.EnterState();

        if (isRootState)
        {
            context.CurrentState = newState;
        }
        else if (currentSuperState != null)
        {
            currentSuperState.SetSubState(newState);
        }
    }

    /// <summary>
    /// Sets new super state
    /// </summary>
    /// <param name="newSuperState">New super state</param>
    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        currentSuperState = newSuperState;
    }

    /// <summary>
    /// Sets new sub state
    /// </summary>
    /// <param name="newSubState">New sub state</param>
    protected void SetSubState(PlayerBaseState newSubState)
    {
        currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }

    /// <summary>
    /// Updates current sub state
    /// </summary>
    private void UpdateSubState()
    {
        if (currentSubState != null)
        {
            currentSubState.UpdateStates();
        }
    }
}
