using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    private MeleeAttackState attackState;

    public void Initialize(MeleeAttackState state)
    {
        attackState = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackState != null)
        {
            attackState.AddTarget(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (attackState != null)
        {
            attackState.RemoveTarget(collision);
        }
    }
}
