using UnityEngine;

public class EnemyRunState : EnemyState
{
    protected bool isTouchingWall;
    protected bool isTouchingLedge;
    protected bool isInMinRange;
    public EnemyRunState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        entity.SetVelocity(enemyData.movementSpeed);
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
    public override void DoChecks()
    {
        base.DoChecks();

        isTouchingLedge = entity.CheckLedge();
        isTouchingWall = entity.CheckWall();
        isInMinRange = entity.CheckPlayerMin();
    }

}
