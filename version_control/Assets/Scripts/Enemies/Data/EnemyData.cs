using UnityEngine;

[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/Enemy Data/Base Data")]

public class EnemyData : ScriptableObject
{
    [Header("Idle State")]
    public float idleTime = 2f;

    [Header("Running State")]
    public float movementSpeed = 5.0f;

    [Header("Player Detected State")]
    public float minDistance = 3.0f;
    public float maxDistance = 4.0f;
    public float rangedActionTime = 1.5f;
    public LayerMask player;

    [Header("Charge State")]
    public float chargeSpeed = 7.0f;
    public float chargeTime = 0.5f;

    [Header("Attack State")]
    public float meleeDistance = 1.0f;
    public float attackDamage = 10.0f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask ground;
}
