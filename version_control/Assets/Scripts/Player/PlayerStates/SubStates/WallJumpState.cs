using System.Runtime.CompilerServices;
using UnityEngine;

public class WallJumpState : AbilityState
{
    private int wallJumpDirection;
    public WallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.movementController.UseJumpInput();
        player.JumpState.ResetJumps();
        player.SetVelocity(playerData.wallJumpVelocity, playerData.wallJumpAngle, wallJumpDirection);
        player.CheckFlip(wallJumpDirection);
        player.JumpState.DecreaseJumps();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        player.Anim.SetFloat("YVelocity", player.RB.linearVelocityY);
        player.Anim.SetFloat("XVelocity", Mathf.Abs(player.RB.linearVelocityX));

        if(Time.time >= startTime + playerData.wallJumpTime)
        {
            isAbilityDone = true;
        }
    }

    public void DetermineDirection(bool isTouchingWall)
    {
       if(isTouchingWall)
       {
            wallJumpDirection = -player.facingDirection;
       }
       else
       {
            wallJumpDirection = player.facingDirection;
       }
    }
}
