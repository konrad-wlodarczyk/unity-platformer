using UnityEngine;

public class ChargeState : EnemyState
{
    protected bool isInMinRange;
    protected bool isTouchingLedge;
    protected bool isTouchingWall;
    protected bool isTimeOver;
    protected bool isInMeleeRange;
    public ChargeState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isInMinRange = entity.CheckPlayerMin();
        isTouchingLedge = entity.CheckLedge();
        isTouchingWall = entity.CheckWall();
        isInMeleeRange = entity.CheckPlayerMelee();
    }

    public override void Enter()
    {
        base.Enter();

        isTimeOver = false;
        entity.SetVelocity(enemyData.chargeSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + enemyData.chargeTime)
        {
            isTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
