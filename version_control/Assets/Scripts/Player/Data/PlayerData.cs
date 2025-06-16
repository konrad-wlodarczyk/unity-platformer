using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Running State")]
    public float movementSpeed = 5.0f;

    [Header("Jump State")]
    public float jumpVelocity = 15f;
    public int jumpsAmount = 1;

    [Header("Airborne State")]
    public float CoyoteTime = 0.3f;

    [Header("Wall Slide State")]
    public float wallSlideVelocity = 3.0f;

    [Header("Wall Jump State")]
    public float wallJumpVelocity = 25.0f;
    public float wallJumpTime = 0.4f;
    public Vector2 wallJumpAngle = new Vector2(1, 2);

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask ground;
}
