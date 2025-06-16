using UnityEngine;

public class WallSlideState : TouchingWallState
{
    
    public WallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            player.SetVelocityY(-playerData.wallSlideVelocity);

            if (grabInput)
            {
                stateMachine.ChangeState(player.WallGrabState);
            }
        }
    }
}
