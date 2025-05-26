using UnityEngine;

public class GroundedState : PlayerState
{
    protected Vector2 input;

    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        input = player.movementController.movementInput;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
