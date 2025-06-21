using UnityEngine;

public class DetectedPlayerState : EnemyState
{
    protected bool isInMinRange, isInMaxRange;
    protected bool rangedAction;
    protected bool isInMeleeRange;
    public DetectedPlayerState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinRange = entity.CheckPlayerMin();
        isInMaxRange = entity.CheckPlayerMax();
        isInMeleeRange = entity.CheckPlayerMelee();
        
    }

    public override void Enter()
    {
        base.Enter();

        rangedAction = false;
        entity.SetVelocity(0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + enemyData.rangedActionTime)
        {
            rangedAction = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
