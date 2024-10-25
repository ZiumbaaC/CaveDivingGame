using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandling : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField ]private float gravity;


    [SerializeField] private bool grounded;

    public Rigidbody2D rb;
    public PlayerInputs input;

    private InputAction move;
    private InputAction jump;
    private InputAction crouch;
    private InputAction attack1;
    private InputAction attack2;
    private InputAction attack3;
    private InputAction block;
    private InputAction interact;
    private InputAction lookUp;
    private InputAction lookDown;

    public bool crouching;
    public bool blocking;
    public bool lookingUp;
    public bool lookingDown;

    private void Awake()
    {
        input = new PlayerInputs();
    }
    void OnEnable()
    {
        move = input.Player.Move;
        jump = input.Player.Jump;
        crouch = input.Player.Crouch;
        attack1 = input.Player.Attack1;
        attack2 = input.Player.Attack2;
        attack3 = input.Player.Attack3;
        block = input.Player.Block;
        interact = input.Player.Interact;
        lookUp = input.Player.LookUp;
        lookDown = input.Player.LookDown;
        move.Enable();
        jump.Enable();
        crouch.Enable();
        attack1.Enable();
        attack2.Enable();
        attack3.Enable();
        block.Enable();
        interact.Enable();
        lookUp.Enable();
        lookDown.Enable();

        jump.performed += Jump;
        attack1.performed += Attack1;
        attack2.performed += Attack2;
        attack3.performed += Attack3;
        interact.performed += Interact;
        
    }
    void OnDisable()
    {
        move.Disable();
        jump.Disable();
        crouch.Disable();
        attack1.Disable();
        attack2.Disable();
        attack3.Disable();
        block.Disable();
        interact.Disable();
        lookUp.Disable();
        lookDown.Disable();
    }

    void Update()
    {
        float moveDirection = move.ReadValue<float>();

        rb.velocity = new Vector2(moveDirection * walkSpeed, rb.velocity.y);

        grounded = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size, 0f, Vector2.down, 0.5f, 3);

        crouching = crouch.IsPressed();
        blocking = block.IsPressed();
        lookingUp = lookUp.IsPressed();
        lookingDown = lookDown.IsPressed();



        if(crouching)
        {
            rb.gravityScale = gravity * 1.5f;
        }
        else
        {
            rb.gravityScale = gravity;
        }
    }

    void Jump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Attack1(InputAction.CallbackContext context)
    {
        Debug.Log("Attack1");
    }

    void Attack2(InputAction.CallbackContext context)
    {
        Debug.Log("Attack2");
    }

    void Attack3(InputAction.CallbackContext context)
    {
        Debug.Log("Attack3");
    }

    void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }
}
