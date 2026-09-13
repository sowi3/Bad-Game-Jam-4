using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFPSinput : MonoBehaviour
{
    InputAction movementInput;
    InputAction attackInput;
    public FPSMovementScript fuckScript;

    void Start()
    {
        movementInput = InputSystem.actions.FindAction("Move");
        attackInput = InputSystem.actions.FindAction("Attack");
    }
    void Update()
    {
        if (movementInput.IsPressed())
        {
            Vector2 moveValue = movementInput.ReadValue<Vector2>() * Time.deltaTime;
            float forwardandbackwards = moveValue.y;
            float sidetoside = moveValue.x;

            if (forwardandbackwards != 0)
            {
                fuckScript.Move(moveValue.y);
            }
            if (sidetoside != 0)
            {
                fuckScript.Rotate(moveValue.x);
            }
        }
        if (attackInput.IsPressed())
        {
            fuckScript.Shoot();
        }
    }
}
