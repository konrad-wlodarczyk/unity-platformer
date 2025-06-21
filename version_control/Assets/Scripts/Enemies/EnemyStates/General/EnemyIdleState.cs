using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected bool flipIdle;
    protected bool isInMinRange;
    protected bool isIdleTimeDone;

    public EnemyIdleState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinRange = entity.CheckPlayerMin();
    }

    public override void Enter()
    {
        base.Enter();

        entity.SetVelocity(0);
        isIdleTimeDone = false;
    }

    public override void Exit()
    {
        base.Exit();

        if(flipIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + enemyData.idleTime)
        {
            isIdleTimeDone = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SetFlip(bool flip)
    {
        flipIdle = flip;
    }
}
