using UnityEngine;

public class LedgeClimbState : PlayerState
{
    private Vector2 detectedPosition;
    private Vector2 cornerPosition;
    private Vector2 startPosition;
    private Vector2 endPosition;

    private bool isHanging;
    private bool isClimbing;
    protected bool jumpInput;

    private int xInput;
    private int yInput;

    public LedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animationBoolName) : base(player, stateMachine, playerData, animationBoolName)
    {
    }

    public override void AnimationFinish()
    {
        base.AnimationFinish();
        player.Anim.SetBool("LedgeClimb", false);
        
    }

    public override void AnimationStart()
    {
        base.AnimationStart();
        isHanging = true;
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity0();
        player.transform.position = detectedPosition;
        cornerPosition = player.DetermineCorner();

        startPosition.Set(cornerPosition.x - (player.facingDirection * playerData.startOffset.x), cornerPosition.y - playerData.startOffset.y);
        endPosition.Set(cornerPosition.x + (player.facingDirection * playerData.endOffset.x), cornerPosition.y + playerData.endOffset.y);

        player.transform.position = startPosition;
    }

    public override void Exit()
    {
        base.Exit();

        isHanging = false;
        if(isClimbing)
        {
            player.transform.position = endPosition;
            isClimbing = false;
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else
        {

            xInput = player.movementController.NormalizedX;
            yInput = player.movementController.NormalizedY;
            jumpInput = player.movementController.jumpInput;


            player.SetVelocity0();
            player.transform.position = startPosition;

            if (yInput == 1 && isHanging && !isClimbing)
            {
                isClimbing = true;
                player.Anim.SetBool("LedgeClimb", true);
            }
            else if (yInput == -1 && isHanging && !isClimbing)
            {
                stateMachine.ChangeState(player.AirborneState);
            }
            else if(jumpInput && isHanging && !isClimbing)
            {
                player.WallJumpState.DetermineDirection(true);
                stateMachine.ChangeState(player.WallJumpState);
            }
        }
    }

    public void SetPosition(Vector2 position) => detectedPosition = position;
}
