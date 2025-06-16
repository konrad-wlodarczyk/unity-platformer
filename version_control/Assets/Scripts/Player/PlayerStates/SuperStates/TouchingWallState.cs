using UnityEngine;

public class TouchingWallState : PlayerState
{
    protected bool isGrounded;
    protected bool isTouchingWall;
    protected bool grabInput;
    protected bool jumpInput;
    protected int xInput;
    protected int yInput;

    public TouchingWallState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isGrounded = player.CheckGround();
        isTouchingWall = player.CheckWall();
    }

    public override void Enter()
    {
        base.Enter();
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
        grabInput = player.movementController.grabInput;
        jumpInput = player.movementController.jumpInput;

        if(jumpInput)
        {
            
            player.WallJumpState.DetermineDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if(isGrounded && !grabInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if(!isTouchingWall || (xInput != player.facingDirection && !grabInput))
        {
            stateMachine.ChangeState(player.AirborneState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
