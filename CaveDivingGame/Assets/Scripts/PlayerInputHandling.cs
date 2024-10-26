using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandling : MonoBehaviour
{
    public enum Diver
    {
        Monk,
        Ranger,
    }

    public Diver diver;

    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;


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
    private InputAction lookHorizontal;
    private InputAction lookVertical;

    public bool crouching;
    public bool blocking;
    public float lookDirectionHorizontal;
    public float lookDirectionVertical;

    public float attack1Cooldown;
    public float attack2Cooldown;
    public float attack3Cooldown;

    public GameObject monkAttack1Prefab;
    public GameObject monkAttack2Prefab;
    public GameObject monkAttack3Prefab;

    public GameObject rangerAttack2Prefab;
    public GameObject rangerAttack3Prefab;

    private float lastDirection = 1;

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
        lookHorizontal = input.Player.LookHorizontal;
        lookVertical = input.Player.LookVertical;
        move.Enable();
        jump.Enable();
        crouch.Enable();
        attack1.Enable();
        attack2.Enable();
        attack3.Enable();
        block.Enable();
        interact.Enable();
        lookHorizontal.Enable();
        lookVertical.Enable();

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
        lookHorizontal.Disable();
        lookVertical.Disable();
    }

    void Update()
    {
        float moveDirection = move.ReadValue<float>();
        lookDirectionHorizontal = lookHorizontal.ReadValue<float>();
        lookDirectionVertical = lookVertical.ReadValue<float>();

        rb.velocity = new Vector2(moveDirection * walkSpeed, rb.velocity.y);

        grounded = Physics2D.BoxCast(transform.position, GetComponent<BoxCollider2D>().size, 0f, Vector2.down, 0.5f, 3);

        crouching = crouch.IsPressed();
        blocking = block.IsPressed();

        if (lookDirectionHorizontal != 0)
        {
            lastDirection = lookDirectionHorizontal;
        }
        else if (moveDirection != 0)
        {
            lastDirection = moveDirection;
        }

        if(crouching)
        {
            rb.gravityScale = gravity * 1.5f;
        }
        else
        {
            rb.gravityScale = gravity;
        }

        attack1Cooldown += Time.deltaTime;
        attack2Cooldown += Time.deltaTime;
        attack3Cooldown += Time.deltaTime;
    }

    void Jump(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Attack1(InputAction.CallbackContext context)
    {
        if (diver == Diver.Monk)
        {
            MonkMoveset.Attack1(transform, monkAttack1Prefab, lastDirection);
        }
        else if (diver == Diver.Ranger)
        {
            RangerMoveset.Attack1(transform, lastDirection, lookDirectionVertical);
        }
    }

    void Attack2(InputAction.CallbackContext context)
    {
        
        if (diver == Diver.Monk)
        {
            MonkMoveset.Attack2(transform, monkAttack2Prefab, lastDirection);
        }
        else if (diver == Diver.Ranger)
        {
            RangerMoveset.Attack2(transform, rangerAttack2Prefab, lastDirection, lookDirectionVertical);
        }
    }

    void Attack3(InputAction.CallbackContext context)
    {
        if (diver == Diver.Monk)
        {
            MonkMoveset.Attack3(transform, monkAttack3Prefab, lastDirection);
        }
        else if (diver == Diver.Ranger)
        {
            RangerMoveset.Attack3(transform, rangerAttack3Prefab, lastDirection, lookDirectionVertical);
        }
    }

    void Interact(InputAction.CallbackContext context)
    {
        Debug.Log("Interact");
    }

    public void Projectile(Vector2 startPos, float time, GameObject prefab, bool affectedByVertLook, Vector2 angle, float direction)
    {
        GameObject projectile = Instantiate(prefab, startPos, Quaternion.identity);
        projectile.GetComponent<ProjectileData>().direction = direction;
        if (affectedByVertLook)
        {
            projectile.GetComponent<ProjectileData>().projectileAngle = angle + new Vector2(0, 0.5f) * lookDirectionVertical;
        }
        else
        {
            projectile.GetComponent<ProjectileData>().projectileAngle = angle;
        }
        Destroy(projectile, time);
    }

    public void GrenadeProjectile(Vector2 startPos, GameObject prefab, Vector2 angle, float direction, float throwForce, float vertLook)
    {
        GameObject projectile = Instantiate(prefab, startPos + new Vector2(1.5f, 0) * direction, Quaternion.identity);

        projectile.GetComponent<Rigidbody2D>().AddForce((angle + new Vector2(0, 0.5f * vertLook)).normalized * throwForce);
    }
}
