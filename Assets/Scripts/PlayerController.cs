using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundLayer;
    //
    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float climbingSpeed = 8f;
    [SerializeField]
    private float jumpForce = 15f;
    //
    private Vector2 moveDirection;
    private bool isLadder;
    private bool isClimbing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
        groundLayer = LayerMask.GetMask("Ground");
    }

    private void Update()
    {
        if (isLadder && Mathf.Abs(moveDirection.y) > 0) {
            isClimbing = true;
        }

        if (moveDirection.x < 0f) {
            spriteRenderer.flipX = true;
            animator.SetBool("isRun", true);
        } else if (moveDirection.x > 0f) {
            spriteRenderer.flipX = false;
            animator.SetBool("isRun", true);
        } else {
            animator.SetBool("isRun", false);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        LadderMovement();
    }

    void OnMove(InputValue iv) 
    {
        moveDirection = iv.Get<Vector2>();
    }

    void OnJump()
    {
        if (IsGrounded()) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
        if (rb.velocity.y > 0f) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }


    private void ApplyMovement()
    {
        if (moveDirection.x == 0) {
            if (IsGrounded()) {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            return;
        }

        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void LadderMovement()
    {
        if (!isClimbing) {
            rb.gravityScale = 4f;
            return;
        }

        rb.velocity = new Vector2(rb.velocity.x, moveDirection.y * climbingSpeed);
        rb.gravityScale = 0f;
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder")) {
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder")) {
            isLadder = false;
            isClimbing = false;
        }
    }
}
