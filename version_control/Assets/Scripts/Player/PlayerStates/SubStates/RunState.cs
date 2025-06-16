using UnityEngine;

public class RunState : GroundedState
{
    public RunState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
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

            player.CheckFlip(xInput);

            player.SetVelocityX(playerData.movementSpeed * xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
