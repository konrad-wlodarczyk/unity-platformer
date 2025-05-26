using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    public IdleState IdleState {  get; private set; }
    public RunState RunState { get; private set; }
    public Animator Anim {  get; private set; }

    public PlayerMovementController movementController { get; private set; }

    public Rigidbody2D RB { get; private set; }

    public int facingDirection {  get; private set; }

    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        IdleState = new IdleState(this, StateMachine, playerData, "IdleAnimation");
        RunState = new RunState(this, StateMachine, playerData, "RunningAnimation");
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

    public void CheckFlip(float xInput)
    {
        if(xInput != 0 && xInput != facingDirection)
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
