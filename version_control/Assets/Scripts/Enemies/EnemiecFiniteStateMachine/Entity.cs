using UnityEngine;

public class Entity : MonoBehaviour
{
    public EnemyData enemyData;

    public EnemyStateMachine stateMachine;
    public Rigidbody2D RB {get; private set;}
    public Animator anim { get; private set;}
    public GameObject alive {  get; private set;}

    private Vector2 workspace;

    public int facingDirection { get; private set;}

    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform ledgeCheck;
    [SerializeField]
    private Transform playerCheck;

    public virtual void Start()
    {
        facingDirection = 1;
        alive = transform.Find("Alive").gameObject;
        RB = alive.GetComponent<Rigidbody2D>();
        anim = alive.GetComponent<Animator>();
        stateMachine = new EnemyStateMachine();
    }

    public virtual void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual void SetVelocity(float velocity)
    {
        workspace.Set(velocity * facingDirection, RB.linearVelocity.y);
        RB.linearVelocity = workspace;
    }

    public virtual bool CheckWall()
    {
        return Physics2D.Raycast(wallCheck.position, alive.transform.right, enemyData.wallCheckDistance, enemyData.ground);
    }
    public virtual bool CheckLedge()
    {
        return Physics2D.Raycast(ledgeCheck.position, Vector2.down, enemyData.wallCheckDistance, enemyData.ground);
    }

    public virtual bool CheckPlayerMin()
    {
        return Physics2D.Raycast(playerCheck.position, alive.transform.right, enemyData.minDistance, enemyData.player);
    }

    public virtual bool CheckPlayerMax()
    {
        return Physics2D.Raycast(playerCheck.position, alive.transform.right, enemyData.maxDistance, enemyData.player);
    }

    public virtual bool CheckPlayerMelee()
    {
        return Physics2D.Raycast(playerCheck.position, alive.transform.right, enemyData.meleeDistance, enemyData.player);
    }

    public void AnimationStart() => stateMachine.currentState.AnimationStart();
    public void AnimationFinish() => stateMachine.currentState.AnimationFinish();

    public void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
