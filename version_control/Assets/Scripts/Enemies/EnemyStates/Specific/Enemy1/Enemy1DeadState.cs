using UnityEngine;

public class Enemy1DeadState : EnemyDeathState
{
    private Enemy1 enemy;
    public Enemy1DeadState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Enemy1 enemy) : base(stateMachine, entity, enemyData, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(0.0f);
    }
}
