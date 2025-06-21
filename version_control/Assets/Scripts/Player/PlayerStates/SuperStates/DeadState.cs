using UnityEngine;

public class DeadState : PlayerState
{
    public DeadState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        player.SetVelocity0();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
}
