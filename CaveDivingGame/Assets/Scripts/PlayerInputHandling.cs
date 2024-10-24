using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandling : MonoBehaviour
{
    public float walkSpeed;
    public float jumpForce;

    public Rigidbody2D rb;
    public PlayerInputs input;

    private InputAction move;
    private InputAction jump;

    private void Awake()
    {
        input = new PlayerInputs();
    }
    void OnEnable()
    {
        move = input.Player.Move;
        jump = input.Player.Jump;
        move.Enable();
        jump.Enable();

        jump.performed += Jump;
    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
    }

    void Update()
    {
        float moveDirection = move.ReadValue<float>();

        rb.velocity = new Vector2(moveDirection * walkSpeed, rb.velocity.y);
    }

    void Jump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
