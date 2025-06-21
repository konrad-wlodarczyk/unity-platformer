using UnityEngine;

public class AnimationEventRelay : MonoBehaviour
{
    public Entity enemy;

    public void AnimationStart()
    {
        enemy.AnimationStart();
    }

    public void AnimationFinish()
    {
        enemy.AnimationFinish();
    }

}
