using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        isFinished = false;
        entity.SetVelocity(0.0f);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
    }
}
