using UnityEngine;

public class Enemy1 : Entity
{
    public Enemy1IdleState idleState {  get; private set; }
    public Enemy1RunState runState { get; private set; }
    public Enemy1DetectedPlayerState detectedPlayerState { get; private set; }
    public Enemy1ChargeState chargeState { get; private set; }

    public MeleeAttackState meleeAttackState { get; private set; }

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Start()
    {
        base.Start();

        runState = new Enemy1RunState(this, stateMachine, this, enemyData, "RunningAnimation");
        idleState = new Enemy1IdleState(this, stateMachine, this, enemyData, "IdleAnimation");
        detectedPlayerState = new Enemy1DetectedPlayerState(stateMachine, this, enemyData, "DetectedPlayerAnimation", this);
        chargeState = new Enemy1ChargeState(stateMachine, this, enemyData, "ChargeAnimation", this);
        meleeAttackState = new MeleeAttackState(stateMachine, this, enemyData, "AttackAnimation", meleeAttackPosition, this);

        stateMachine.Initialize(runState);
    }

}
