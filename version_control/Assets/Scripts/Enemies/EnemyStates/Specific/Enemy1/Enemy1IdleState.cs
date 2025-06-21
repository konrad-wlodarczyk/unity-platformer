using UnityEngine;

public class Enemy1IdleState : EnemyIdleState
{
    private Enemy1 enemy;
    public Enemy1IdleState(Enemy1 enemy, EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
        this.enemy = enemy;
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

        if(isInMinRange)
        {
            stateMachine.ChangeState(enemy.detectedPlayerState);
        }

        if(isIdleTimeDone)
        {
            stateMachine.ChangeState(enemy.runState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
