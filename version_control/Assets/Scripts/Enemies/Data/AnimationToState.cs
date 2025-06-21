using UnityEngine;

public class AnimationToState : MonoBehaviour 
{
    public EnemyAttackState attackState;

    private void AnimationStart()
    {
        attackState.AnimationStart();
    }

    private void AnimationFinish()
    {
        attackState.AnimationFinish();
    }
}
