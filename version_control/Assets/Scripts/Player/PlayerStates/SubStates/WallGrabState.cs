using UnityEngine;

public class WallGrabState : TouchingWallState
{
    private Vector2 holdPosition;

    public WallGrabState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();

        holdPosition = player.transform.position;

        HoldPosition();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            HoldPosition();

            if (!grabInput)
            {
                stateMachine.ChangeState(player.WallSlideState);
            }
        }

    }

    private void HoldPosition()
    {
        player.transform.position = holdPosition;

        player.SetVelocityX(0);
        player.SetVelocityY(0);

    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
