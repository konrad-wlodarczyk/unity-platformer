using System.Runtime.CompilerServices;
using UnityEngine;

public class DashState : AbilityState
{
    public bool canDash { get; private set; }

    private float lastDashTime;
    private Vector2 dashDirection;
    private Vector2 lastAfterImage;
    private bool isWindup;

    public DashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
        : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        canDash = false;
        isAbilityDone = false;

        player.movementController.UseDashInput();

        player.RB.gravityScale = 0f;
        player.SetVelocity(0f, Vector2.zero);

        lastAfterImage = player.transform.position;

        isWindup = true;
        startTime = Time.time;

        int xInput = player.movementController.NormalizedX;
        dashDirection = new Vector2(xInput == 0 ? player.facingDirection : xInput, 0).normalized;
    }
    public override void Exit()
    {
        base.Exit();
        player.RB.linearDamping = 0f;
        player.RB.gravityScale = 5;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isExitingState) return;

        if (isWindup)
        {
            player.SetVelocity(0f, Vector2.zero);

            if (Time.time >= startTime + playerData.windupDuration)
            {
                isWindup = false;
                startTime = Time.time; 
            }

            return;
        }

        player.SetVelocity(playerData.dashVelocity, dashDirection);

        if (Vector2.Distance(player.transform.position, lastAfterImage) >= playerData.distanceBetweenImages)
        {
            PlaceAfterImage();
        }

        if (Time.time >= startTime + playerData.dashTime)
        {
            player.SetVelocity(0f, Vector2.zero);
            isAbilityDone = true;
            lastDashTime = Time.time;
        }
    }


    public bool CanDash()
    {
        return canDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetDash() => canDash = true;

    private void CheckAfterImage()
    {
        if (Vector2.Distance(player.transform.position, lastAfterImage) >= playerData.distanceBetweenImages)
        {
            PlaceAfterImage();
        }
    }

    private void PlaceAfterImage()
    {
        AfterImagePool.Instance.GetFromPool();
        lastAfterImage = player.transform.position;
    }
}
