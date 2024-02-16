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
    //
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpForce = 15f;
    //
    private Vector2 moveDirection;
    private bool isGrounded = false;
    private int groundLayer;
    private Transform playerGroundLocation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        groundLayer = LayerMask.GetMask("Ground");
        playerGroundLocation = transform.Find("PlayerGround");
    }

    private void FixedUpdate()
    {
        GroundCheck();

        ApplyMovement();
    }

    void OnMove(InputValue iv) 
    {
        moveDirection = iv.Get<Vector2>();
    }

    void OnJump()
    {
        if (isGrounded) {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //rb.velocity = rb.velocity + Vector2.up * jumpForce;
            Debug.Log("IsGrounded - Jump: " + moveDirection.y);
            isGrounded = false;
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D hit;
        float distance = 0.5f;

        hit = Physics2D.Raycast(playerGroundLocation.position, Vector2.down, distance, groundLayer);

        isGrounded = hit.collider != null;
    }

    private void ApplyMovement()
    {
        rb.velocity += new Vector2(moveDirection.x * moveSpeed * Time.deltaTime, 0f);

        if (moveDirection.x == 0 && isGrounded == true) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (moveDirection.x < 0f) {
            spriteRenderer.flipX = true;
        } else if (moveDirection.x > 0f) {
            spriteRenderer.flipX = false;
        }
    }
}
