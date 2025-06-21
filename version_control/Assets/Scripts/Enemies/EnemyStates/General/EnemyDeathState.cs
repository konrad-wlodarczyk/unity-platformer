using UnityEngine;

public class EnemyDeathState : EnemyState
{
    public EnemyDeathState(EnemyStateMachine stateMachine, Entity entity, EnemyData enemyData, string animationBoolName) : base(stateMachine, entity, enemyData, animationBoolName)
    {
    }
}
