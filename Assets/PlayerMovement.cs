using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Crouch,
    Jump,
    Fall,
    Dead,
    Attack,
}
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float maxSpeed = 5;
    public float acceleration = 20;
    public float deacceleration = 4;

    internal float velocityX;

    [Header("Jump")]
    public float jumpPower = 8;
    public float groundCheckDistance = 0.01f;

    bool onGround = true;
    float groundCheckLenght;
    int maxJumps = 1;
    int currentJumps = 0;

    Rigidbody2D rb2D;
    public PlayerState state = PlayerState.Idle;

    private float attackDuration = 0.5f; // Adjust the duration of the attack animation

    private void Start()
    {
        Physics2D.queriesStartInColliders = false;
        rb2D = GetComponent<Rigidbody2D>();
        var collider = GetComponent<Collider2D>();
        groundCheckLenght = collider.bounds.size.y + groundCheckDistance;
    }

    private void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            state = PlayerState.Attack;
            Invoke("EndAttackState", attackDuration); // End attack state after attack duration
        }
    }

    private void EndAttackState()
    {
        // Check if the current state is still Attack before switching to Idle
        if (state == PlayerState.Attack)
        {
            state = PlayerState.Idle;
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && currentJumps < maxJumps)
        {
            onGround = false;
            currentJumps++;
            var velocity = rb2D.velocity;
            velocity.y = jumpPower;
            rb2D.velocity = velocity;
            state = PlayerState.Jump;
            return;
        }

        if (Input.GetButtonUp("Jump") && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.25f);
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLenght);

        if (onGround)
            currentJumps = 0;
    }

    private void GravityAdjust()
    {
        if (rb2D.velocity.y < 0)
            rb2D.gravityScale = 4;
        else
            rb2D.gravityScale = 1;
    }

    private void HorizontalMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        if (Input.GetKey(KeyCode.LeftControl) && onGround)
        {
            maxSpeed = 0;
            state = PlayerState.Crouch;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            maxSpeed = 5;
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            state = PlayerState.Crouch;

            velocityX = x * maxSpeed;
            rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
        }
        else if (onGround)
        {
            if (x == 0)
            {
                state = PlayerState.Idle;
            }
            else
            {
                state = PlayerState.Run;
            }
        }

        velocityX += x * acceleration * Time.deltaTime;
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (x == 0 || (x < 0 == velocityX > 0))
        {
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }

    void Update()
    {
        HorizontalMovement();
        PlayerAttack();
        Jump();
        GravityAdjust();
    }
}
