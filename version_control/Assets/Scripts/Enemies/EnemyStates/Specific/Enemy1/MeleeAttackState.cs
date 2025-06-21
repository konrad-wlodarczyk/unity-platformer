using UnityEngine;

public class MeleeAttackState : EnemyAttackState
{
    private Enemy1 enemy;
    protected bool isInMinRange;
    public MeleeAttackState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Transform attackHitbox, Enemy1 enemy) : base(stateMachine, entity, enemyData, animationBoolName, attackHitbox)
    {
        this.enemy = enemy;
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
    }

    public override void AnimationStart()
    {
        base.AnimationStart();

        Collider2D[] targets = Physics2D.OverlapCircleAll(attackHitbox.position, enemyData.meleeDistance, enemyData.player);

        foreach (Collider2D target in targets)
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(enemyData.attackDamage);
            }
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isInMinRange = entity.CheckPlayerMin();
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

        DoChecks();

        if(isFinished)
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
