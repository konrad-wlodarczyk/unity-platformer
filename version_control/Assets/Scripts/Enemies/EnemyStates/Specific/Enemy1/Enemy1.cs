using Unity.VisualScripting;
using UnityEngine;

public class Enemy1 : Entity, IDamageable
{
    public GameObject AttackHitbox;
    public Enemy1IdleState idleState {  get; private set; }
    public Enemy1RunState runState { get; private set; }
    public Enemy1DetectedPlayerState detectedPlayerState { get; private set; }
    public Enemy1ChargeState chargeState { get; private set; }
    public Enemy1DeadState DeadState { get; private set; }

    public MeleeAttackState meleeAttackState { get; private set; }

    protected float currentHealth;

    public int experienceAmount = 100;

    public override void Start()
    {
        base.Start();

        runState = new Enemy1RunState(this, stateMachine, this, enemyData, "RunningAnimation");
        idleState = new Enemy1IdleState(this, stateMachine, this, enemyData, "IdleAnimation");
        detectedPlayerState = new Enemy1DetectedPlayerState(stateMachine, this, enemyData, "DetectedPlayerAnimation", this);
        chargeState = new Enemy1ChargeState(stateMachine, this, enemyData, "ChargeAnimation", this);
        meleeAttackState = new MeleeAttackState(stateMachine, this, enemyData, "AttackAnimation", this);
        DeadState = new Enemy1DeadState(stateMachine, this, enemyData, "DeathAnimation", this);

        stateMachine.Initialize(runState);

        currentHealth = enemyData.maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            ExperienceManager.Instance.AddExperience(experienceAmount);
            stateMachine.ChangeState(DeadState);
        }
    }

}
