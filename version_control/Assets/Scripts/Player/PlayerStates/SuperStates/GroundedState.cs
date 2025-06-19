using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class GroundedState : PlayerState
{
    protected int xInput;
    protected int yInput;

    protected Vector2 input;
    private bool jumpInput;
    private bool grabInput;
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingLedge;
    private bool dashInput;
    private bool attackInput;

    public GroundedState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckGround();
        isTouchingWall = player.CheckWall();
        isTouchingLedge = player.CheckLedge();
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetJumps();
        player.DashState.ResetDash();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        xInput = player.movementController.NormalizedX;
        yInput = player.movementController.NormalizedY;

        input = player.movementController.movementInput;
        jumpInput = player.movementController.jumpInput;
        dashInput = player.movementController.dashInput;

        grabInput = player.movementController.grabInput;
        attackInput = player.movementController.attackInput;

        if (jumpInput == true && player.JumpState.CanJump())
        {
            stateMachine.ChangeState(player.JumpState);
        }
        else if (!isGrounded)
        {
            player.AirborneState.StartCoyote();
            stateMachine.ChangeState(player.AirborneState);
        }
        else if (isTouchingWall && grabInput && isTouchingLedge)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (dashInput && player.DashState.CanDash())
        {
            stateMachine.ChangeState(player.DashState);
        }
        else if (attackInput)
        {
            player.StateMachine.ChangeState(player.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
