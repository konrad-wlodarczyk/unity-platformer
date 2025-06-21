using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AbilityState
{

    private int xInput;
    private bool shouldCheckFlip;
    protected int attackCounter;

    private List<IDamageable> targets = new List<IDamageable>();

    public AttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if(attackCounter > 1)
        {
            attackCounter = 0;
        }

        player.Anim.SetInteger("AttackCounter", attackCounter);
        player.AttackHitbox.GetComponent<AttackHitbox>().Initialize(this);

    }

    public override void Exit()
    {
        base.Exit();

        attackCounter++;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.movementController.NormalizedX;

        if (shouldCheckFlip)
        {
            player.CheckFlip(xInput);
        }
    }

    public void SetFlipCheck(bool value)
    {
        shouldCheckFlip = value;
    }

    public void AddTarget(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("Added target: " + damageable);
            targets.Add(damageable);
        }
    }

    public void RemoveTarget(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            Debug.Log("removed target: " + damageable);
            targets.Remove(damageable);
        }
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();

        isAbilityDone = true;
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
        CheckAttack();
    }   

    private void CheckAttack()
    {
        Debug.Log("Checking attack. Target count: " + targets.Count);

        foreach (IDamageable item in targets)
        {
            item.Damage(10f);
        }
    }

}