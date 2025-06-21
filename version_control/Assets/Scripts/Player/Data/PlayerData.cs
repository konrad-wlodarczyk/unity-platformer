using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Player Statistics")]
    public float maxHealth = 100.0f;
    public float maxStamina = 50.0f;
    public float agility = 1f;

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

    [Header("Ledge Climb State")]
    public Vector2 startOffset;
    public Vector2 endOffset;

    [Header("Dash State")]
    public float dashCooldown = 0.5f;
    public float dashTime = 0.2f;
    public float dashVelocity = 15f;
    public float drag = 10f;
    public float distanceBetweenImages = 0.5f;
    public float windupDuration = 0.5f;

    [Header("Check Variables")]
    public float groundCheckRadius = 0.3f;
    public float wallCheckDistance = 0.5f;
    public LayerMask ground;
}
