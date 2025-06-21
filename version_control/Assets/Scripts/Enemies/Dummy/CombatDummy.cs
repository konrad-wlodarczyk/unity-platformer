using UnityEngine;

public class CombatDummy : MonoBehaviour, IDamageable
{
    private Animator anim;

    public float currentHealth = 100f;

    public void Damage(float amount)
    {
        anim.SetTrigger("Damage");
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            ExperienceManager.Instance.AddExperience(100);
            anim.SetTrigger("Death");
        }
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }



}
