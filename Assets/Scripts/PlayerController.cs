using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public int moveSPD;
    public Rigidbody2D rb;
    public Vector2 moveInput;

    [Header("Interact Variables")]
    public bool interactInput; 

    private void Update()
    {
        if (interactInput)
        {
            interactInput = false;
            TryInteract();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSPD;
    }

    public void OnmoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            interactInput = true;
        }
    }

    private void TryInteract()
    {
        Debug.Log("Pressed Interact Button");
    }
}
