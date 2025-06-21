using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour, IDamageable
{
    public GameObject AttackHitbox;
    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState IdleState {  get; private set; }
    public RunState RunState { get; private set; }
    public JumpState JumpState { get; private set; }
    public AirborneState AirborneState { get; private set; }
    public LandState LandState { get; private set; }
    public WallSlideState WallSlideState { get; private set; }
    public WallGrabState WallGrabState { get; private set; }
    public WallJumpState WallJumpState { get; private set; }
    public LedgeClimbState LedgeClimbState { get; private set; }
    public DashState DashState { get; private set; }
    public AttackState AttackState { get; private set; }
    public DeadState DeadState { get; private set; }
    public Animator Anim {  get; private set; }
    public PlayerMovementController movementController { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D BoxCollider { get; private set; }
    public int facingDirection {  get; private set; }
    public float currentHealth { get; private set; }

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private Transform wallCheck;

    [SerializeField]
    private PlayerData playerData;

    [SerializeField]
    private Transform ledgeCheck;

    [SerializeField]
    private HealthBar healthbar;

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
        LedgeClimbState = new LedgeClimbState(this, StateMachine, playerData, "LedgeClimbStateAnimation");
        DashState = new DashState(this, StateMachine, playerData, "InAirAnimation");
        AttackState = new AttackState(this, StateMachine, playerData, "AttackAnimation");
        DeadState = new DeadState(this, StateMachine, playerData, "DeathAnimation");
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        movementController = GetComponent<PlayerMovementController>();
        RB = GetComponent<Rigidbody2D>();
        BoxCollider = GetComponent<BoxCollider2D>();

        facingDirection = 1;
        currentHealth = playerData.maxHealth;
        
        StateMachine.Initialize(IdleState);

        playerData.experience = 0;

        ExperienceManager.Instance.ExperienceChange += HandleExperienceGain;
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

    public void SetVelocity(float velocity, Vector2 direction)
    {
        workspace = direction * velocity;
        RB.linearVelocity = workspace;
    }

    public void SetVelocity0()
    {
        RB.linearVelocity = Vector2.zero;
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

    public bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.right * facingDirection, playerData.wallCheckDistance, playerData.ground);
    }

    public Vector2 DetermineCorner()
    {
        RaycastHit2D xHit = Physics2D.Raycast(wallCheck.position, Vector2.right * facingDirection, playerData.wallCheckDistance, playerData.ground);
        float xDistance = xHit.distance;
        workspace.Set(xDistance * facingDirection, 0);
        RaycastHit2D yHit = Physics2D.Raycast(ledgeCheck.position + (Vector3)(workspace), Vector2.down, ledgeCheck.position.y - wallCheck.position.y, playerData.ground);
        float yDistance = yHit.distance;

        workspace.Set(wallCheck.position.x + (xDistance * facingDirection), ledgeCheck.position.y - yDistance);
        return workspace;
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

    public void Damage(float amount)
    {
        currentHealth -= amount;
        healthbar.SetHealth(currentHealth, playerData.maxHealth);

        if (currentHealth <= 0 )
        {
            StateMachine.ChangeState(DeadState);
        }
    }

    private void OnDestroy()
    {
        ExperienceManager.Instance.ExperienceChange -= HandleExperienceGain;
    }

    private void HandleExperienceGain(int amount)
    {
        playerData.AddExperience(amount);
    }
}
