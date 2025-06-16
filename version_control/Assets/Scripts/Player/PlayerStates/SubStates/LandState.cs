using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class LandState : GroundedState
{
    public LandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (xInput != 0)
            {
                stateMachine.ChangeState(player.RunState);
            }
            else if (isFinished)
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }
}
