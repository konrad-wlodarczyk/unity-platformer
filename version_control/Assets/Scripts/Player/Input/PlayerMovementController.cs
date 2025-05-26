using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public Vector2 movementInput {  get; private set; }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void OnJumpInput(InputAction.CallbackContext context)
    {

    }
}
