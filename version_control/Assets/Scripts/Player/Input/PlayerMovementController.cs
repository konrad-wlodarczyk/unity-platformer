using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Vector2 movementInput { get; private set; }
    public bool jumpInput { get; private set; }
    public bool grabInput { get; private set; }
    public bool dashInput { get; private set; }
    public bool attackInput { get; private set; }
    public int NormalizedX { get; private set; }
    public int NormalizedY { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.3f;

    private float jumpStartTime;
    private float dashStartTime;

    private void Update()
    {
        CheckJumpTime();
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();

        NormalizedX = Mathf.RoundToInt(movementInput.x);
        NormalizedY = Mathf.RoundToInt(movementInput.y); 
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            jumpInput = true;
            jumpStartTime = Time.time;
        }
    }

    public void OnGrabInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grabInput = true;
        }

        if (context.canceled)
        {
            grabInput = false;
        }
    }

    public void OnDashInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            dashInput = true;
            dashStartTime = Time.time;
        }
        if (context.canceled)
        {
            dashInput = false;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackInput = true;
        }
        if (context.canceled)
        {
            attackInput = false;
        }
    }

    private void CheckJumpTime()
    {
        if(Time.time >= jumpStartTime + inputHoldTime)
        {
            jumpInput = false;
        }
    }

    private void CheckDashTime()
    {
        if (Time.time >= dashStartTime + inputHoldTime)
        {
            dashInput = false;
        }
    }

    public void UseJumpInput() => jumpInput = false;
    public void UseDashInput() => dashInput = false;
}
