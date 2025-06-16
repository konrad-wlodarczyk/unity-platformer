using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState IdleState {  get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public AirborneState AirborneState { get; private set; }
    public LandState LandState { get; private set; }
    public WallSlideState WallSlideState { get; private set; }
    public WallGrabState WallGrabState { get; private set; }
    public WallJumpState WallJumpState { get; private set; }
    public Animator Anim {  get; private set; }

    public PlayerMovementController movementController { get; private set; }

    public Rigidbody2D RB { get; private set; }

    public int facingDirection {  get; private set; }

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this, StateMachine, playerData, "IdleAnimation");
        RunState = new RunState(this, StateMachine, playerData, "RunningAnimation");
        JumpState = new JumpState(this, StateMachine, playerData, "InAirAnimation");
        AirborneState = new AirborneState(this, StateMachine, playerData, "InAirAnimation");
        LandState = new LandState(this, StateMachine, playerData, "LandAnimation");
        WallSlideState = new WallSlideState(this, StateMachine, playerData, "WallSlideAnimation");
        WallGrabState = new WallGrabState(this, StateMachine, playerData, "WallGrabAnimation");
        WallJumpState = new WallJumpState(this, StateMachine, playerData, "InAirAnimation");

    }

    private void Start() 
    {
        Anim = GetComponent<Animator>();
        movementController = GetComponent<PlayerMovementController>();
        RB = GetComponent<Rigidbody2D>();

        facingDirection = 1;

        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.currentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.currentState.PhysicsUpdate();
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity, RB.linearVelocity.y);
        RB.linearVelocity = workspace;
    }

    public void SetVelocityY(float velocity)
    {
        workspace.Set(RB.linearVelocity.x, velocity);
        RB.linearVelocity = workspace;
    }

    public void SetVelocity(float velocity, Vector2 angle, int direction)
    {
        angle.Normalize();
        workspace.Set(angle.x * velocity * direction, angle.y * velocity);
        RB.linearVelocity = workspace;
    }

    public bool CheckGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.ground);
    }

    public bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, playerData.wallCheckDistance, playerData.ground);
    }

    public bool CheckBackWall()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.right * -facingDirection, playerData.wallCheckDistance, playerData.ground);
    }

    private void AnimationStart() => StateMachine.currentState.AnimationStart();
    private void AnimationFinish() => StateMachine.currentState.AnimationFinish();
    public void CheckFlip(float xInput)
    {

        if (xInput != 0 && xInput != facingDirection)
        {
            Flip();
        }
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f); 
    }
}
