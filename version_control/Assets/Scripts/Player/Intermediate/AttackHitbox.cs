using UnityEngine;

public class AttackHitbox : MonoBehaviour
{
    private AttackState attackState;

    public void Initialize(AttackState state)
    {
        attackState = state;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(attackState != null) 
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
