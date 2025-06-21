using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : EnemyAttackState
{
    private Enemy1 enemy;
    protected bool isInMinRange;
    protected List<IDamageable> targets = new List<IDamageable>();
    public MeleeAttackState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName, Enemy1 enemy) : base(stateMachine, entity, enemyData, animationBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.AttackHitbox.GetComponent<EnemyAttackHitbox>().Initialize(this);

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

    public void AddTarget(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponentInParent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("Added target: " + damageable);
            targets.Add(damageable);
        }
    }

    public void RemoveTarget(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponentInParent<IDamageable>();

        if (damageable != null)
        {
            //Debug.Log("removed target: " + damageable);
            targets.Remove(damageable);
        }
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
        CheckAttack();
    }

    private void CheckAttack()
    {
        //Debug.Log("Checking attack. Target count: " + targets.Count);

        foreach (IDamageable item in targets)
        {
            item.Damage(20);
        }
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isInMinRange = entity.CheckPlayerMin();
    }
}
