using UnityEngine;

public class JumpState : AbilityState
{
    private int jumpsLeft;

    public JumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
        jumpsLeft = playerData.jumpsAmount;
    }
    public override void Enter()
    {
        base.Enter();

        player.movementController.UseJumpInput();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone = true;
        jumpsLeft--;
    }

    public bool CanJump()
    {
        if (jumpsLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetJumps()
    {
        jumpsLeft = playerData.jumpsAmount;
    }

    public void DecreaseJumps()
    {
        jumpsLeft--;
    }
}
