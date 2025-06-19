using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : AbilityState
{

    private int xInput;
    private bool shouldCheckFlip;
    protected int attackCounter;

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


    public override void AnimationFinish()
    {
        base.AnimationFinish();
        Debug.Log("Animation Finished");

        isAbilityDone = true;
    }
}