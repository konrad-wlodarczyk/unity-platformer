using UnityEngine;

public class EnemyAttackState : EnemyState
{
    protected Transform attackHitbox;

    public EnemyAttackState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Transform attackHitbox) : base(stateMachine, entity, enemyData, animationBoolName)
    {
        this.attackHitbox = attackHitbox;
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

        entity.ats.attackState = this;
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

    public virtual void AnimationStart() { }

    public virtual void AnimationFinish() 
    {
        isFinished = true;
    }
}
