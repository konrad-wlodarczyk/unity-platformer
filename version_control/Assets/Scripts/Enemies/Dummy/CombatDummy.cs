using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    private Animator anim;

    public void Damage(float amount)
    {
        Debug.Log("Ale mu wyjebales");
        anim.SetTrigger("Damage");
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }



}
