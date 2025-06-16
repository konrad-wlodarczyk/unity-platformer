using UnityEngine;

public class AirborneState : PlayerState
{
    private bool isGrounded;
    private bool isTouchingWall;
    private bool isTouchingBackWall;
    private int xInput;
    private bool jumpInput;
    private bool CoyoteTime;
    private bool grabInput;

    public AirborneState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = player.CheckGround();
        isTouchingWall = player.CheckWall();
        isTouchingBackWall = player.CheckBackWall();
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

        CheckCoyote();

        xInput = player.movementController.NormalizedX;
        jumpInput = player.movementController.jumpInput;
        grabInput = player.movementController.grabInput;

        if (isGrounded && player.RB.linearVelocity.y < 0.01f)
        {
            stateMachine.ChangeState(player.LandState);
        }
        else if(jumpInput && (isTouchingWall || isTouchingBackWall))
        {
            player.WallJumpState.DetermineDirection(isTouchingWall);
            stateMachine.ChangeState(player.WallJumpState);
        }
        else if (jumpInput && player.JumpState.CanJump())
        {
            
            stateMachine.ChangeState(player.JumpState);
        }
        else if (isTouchingWall && grabInput)
        {
            stateMachine.ChangeState(player.WallGrabState);
        }
        else if (isTouchingWall && xInput == player.facingDirection && player.RB.linearVelocityY <= 0)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else
        {
            player.CheckFlip(xInput);
            player.SetVelocityX(playerData.movementSpeed * xInput);

            player.Anim.SetFloat("YVelocity", player.RB.linearVelocity.y);
            player.Anim.SetFloat("XVelocity", Mathf.Abs(player.RB.linearVelocity.x));
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    private void CheckCoyote()
    {
        if(CoyoteTime == true && Time.time > startTime + playerData.CoyoteTime)
        {
            CoyoteTime = false;
            player.JumpState.DecreaseJumps();
        }
    }

    public void StartCoyote()
    {
        CoyoteTime = true;
    }
}
