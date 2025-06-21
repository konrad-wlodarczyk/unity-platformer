using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachine stateMachine;
    protected Entity entity;
    protected EnemyData enemyData;

    private string animationBoolName;
    protected float startTime;
    protected bool isFinished;
    
    public EnemyState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName)
    {
        this.stateMachine = stateMachine;
        this.entity = entity;
        this.enemyData = enemyData;
        this.animationBoolName = animationBoolName;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animationBoolName, true);
        DoChecks();
    }

    public virtual void Exit()
    {
        entity.anim.SetBool(animationBoolName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationStart() { }
    public virtual void AnimationFinish() => isFinished = true;
}
