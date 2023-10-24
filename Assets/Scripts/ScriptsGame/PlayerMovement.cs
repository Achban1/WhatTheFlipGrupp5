using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public enum PlayerID
{
    Player1,
    Player2
}

public enum PlayerState
{
    Idle,
    Walk,
    Run,
    Crouch,
    Jump,
    Fall,
    Dead,
    Attack
}

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [Header("Player ID")]
    public PlayerID playerID;

    [Header("Movement")]
    public float maxSpeed = 5;
    public float acceleration = 20;
    public float deacceleration = 4;
    internal float velocityX;

    [Header("Jump")]
    public float jumpPower = 8;
    public float groundCheckDistance = 0.01f;

    bool onGround = true;
    float groundCheckLength;
    int maxJumps = 1;
    static int currentJumps = 0;

    Rigidbody2D rb2D;
    public PlayerState state = PlayerState.Idle;

    private float attackDuration = 0.5f;

    bool isBouncing = false;

    bool canMove = true;
    bool canMoveAtAll = true;       //to turn off all movement when changing scene or flipping

    private void Start()
    {
        Instance = this;
        Physics2D.queriesStartInColliders = false;
        rb2D = GetComponent<Rigidbody2D>();
        var collider = GetComponent<Collider2D>();
        groundCheckLength = collider.bounds.size.y + groundCheckDistance;
    }

    private void PlayerAttack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            state = PlayerState.Attack;
            Invoke("EndAttackState", attackDuration);
        }
    }

    private void EndAttackState()
    {
        if (state == PlayerState.Attack)
        {
            state = PlayerState.Idle;
        }
    }

    private float GetPlayerInputHorizontal()
    {
        switch (playerID)
        {
            case PlayerID.Player1:
                return Input.GetKey(KeyCode.A) ? -1 : Input.GetKey(KeyCode.D) ? 1 : 0;
            case PlayerID.Player2:
                return Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
            default:
                return 0;
        }
    }

    private bool GetPlayerJumpInputDown()
    {
        switch (playerID)
        {
            case PlayerID.Player1:
                return Input.GetKeyDown(KeyCode.W);
            case PlayerID.Player2:
                return Input.GetKeyDown(KeyCode.UpArrow);
            default:
                return false;
        }
    }

    private bool GetPlayerJumpInputReleased()
    {
        switch (playerID)
        {
            case PlayerID.Player1:
                return Input.GetKeyUp(KeyCode.W);
            case PlayerID.Player2:
                return Input.GetKeyUp(KeyCode.UpArrow);
            default:
                return false;
        }
    }
    private void GravityAdjust()
    {
        if (rb2D.velocity.y < 0)
            rb2D.gravityScale = 4;
        else
            rb2D.gravityScale = 1;
    }
    private void Jump()
    {
        if (GetPlayerJumpInputDown() && currentJumps < maxJumps)
        {
            onGround = false;
            currentJumps++;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpPower);
            state = PlayerState.Jump;
        }
        else if (GetPlayerJumpInputReleased() && rb2D.velocity.y > 0)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
        }

        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundCheckLength);
        if (onGround)
            currentJumps = 0;
    }

    private void HorizontalMovement()
    {
        float x = GetPlayerInputHorizontal();

        if (x == 0)
        {
            state = PlayerState.Idle;
        }
        else
        {
            state = PlayerState.Run;
        }

        velocityX += x * acceleration * Time.deltaTime;
        velocityX = Mathf.Clamp(velocityX, -maxSpeed, maxSpeed);

        if (x == 0 || (x < 0 == velocityX > 0))
        {
            velocityX *= 1 - deacceleration * Time.deltaTime;
        }

        rb2D.velocity = new Vector2(velocityX, rb2D.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement otherPlayer = collision.gameObject.GetComponent<PlayerMovement>();
        if (otherPlayer != null && !isBouncing)
        {

            float bounce = 1f;

            Vector2 bounceDirection = (this.rb2D.position - otherPlayer.rb2D.position).normalized;
            Vector2 bounceForce = bounceDirection * bounce * Mathf.Abs(rb2D.velocity.magnitude);

            rb2D.AddForce(bounceForce, ForceMode2D.Impulse);
            otherPlayer.rb2D.AddForce(-bounceForce, ForceMode2D.Impulse); // Bounce the other player in the opposite direction

            isBouncing = true;
            Invoke(nameof(StopBounce), 0.3f);

            DisableMovement();
            otherPlayer.DisableMovement();
        }
    }

    public void DisableMovement()
    {
        canMove = false;
        Invoke(nameof(EnableMovement), 0.5f);  // Enable movement after 0.5 seconds
    }

    void EnableMovement()
    {
        canMove = true;
    }
    public void DisableAllMovement()
    {
        canMoveAtAll = false;
        rb2D.velocity = Vector2.zero;
        rb2D.gravityScale = 0f;
        Invoke(nameof(EnableAllMovement),0.5f);
        //turnof colliders
    }
    void EnableAllMovement()
    {
        rb2D.gravityScale = 1f;
        canMoveAtAll = true;
    }

    void StopBounce()
    {
        isBouncing = false;
    }

    void Update()
    {
        if (!canMoveAtAll)
        {
            return;
        }

        if (canMove)
        {
            HorizontalMovement();
        }
        PlayerAttack();
        Jump();
        GravityAdjust();
    }
}
