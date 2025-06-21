using UnityEngine;

public class Enemy1ChargeState : ChargeState
{
    private Enemy1 enemy;
    public Enemy1ChargeState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Enemy1 enemy) : base(stateMachine, entity, enemyData, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void DoChecks()
    {
        base.DoChecks();
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

        if (isInMeleeRange)
        {
            stateMachine.ChangeState(enemy.meleeAttackState);
        }
        else if (!isTouchingLedge || isTouchingWall)
        {
            stateMachine.ChangeState(enemy.idleState);
        }
        else if(isTimeOver)
        {
            if(isInMinRange)
            {
                stateMachine.ChangeState(enemy.detectedPlayerState);
            }
            else
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
