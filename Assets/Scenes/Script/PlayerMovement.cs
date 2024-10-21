using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables for movement speed and jump force
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private bool isJumping = false;

    // Reference to Rigidbody2D component
    private Rigidbody2D rb;

    // Ground check variables
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded;

    // Falling and Gravity control
    public float fallMultiplier = 2.5f;    // Faster fall speed when not jumping
    public float lowJumpMultiplier = 2f;   // Make short jumps feel snappier

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        // Apply better gravity for a smoother jump and fall
        if (rb.velocity.y < 0)  // When falling
        {
            // Apply a stronger downward force
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) // When jump key is released early
        {
            // Apply a smaller upward force for short, quick jumps
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        // Check if player has landed back on the ground
        if (isGrounded)
        {
            isJumping = false;
        }
    }
}



