using UnityEngine;

public class Enemy1DetectedPlayerState : DetectedPlayerState
{
    private Enemy1 enemy;
    public Enemy1DetectedPlayerState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Enemy1 enemy) : base(stateMachine, entity, enemyData, animationBoolName)
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

        if(isInMeleeRange)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if(rangedAction)
        {
            enemy.idleState.SetFlip(false);
            stateMachine.ChangeState(enemy.chargeState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
