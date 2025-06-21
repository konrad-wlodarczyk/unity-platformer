using UnityEngine;

public class Enemy1RunState : EnemyRunState
{
    private Enemy1 enemy;
    public Enemy1RunState(Enemy1 enemy, EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
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

        if(isTouchingWall || !isTouchingLedge)
        {
            enemy.idleState.SetFlip(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
