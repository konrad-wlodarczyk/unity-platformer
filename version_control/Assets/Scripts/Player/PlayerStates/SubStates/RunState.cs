using UnityEngine;
using UnityEngine.EventSystems;

public class RunState : GroundedState
{
    private bool dashInput;

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

        dashInput = player.movementController.dashInput;

        player.CheckFlip(xInput);

            player.SetVelocityX(playerData.movementSpeed * xInput);

            if (xInput == 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (dashInput && player.DashState.CanDash())
            {
                stateMachine.ChangeState(player.DashState);
            }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
