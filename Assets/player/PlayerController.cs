using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the character
    public float jumpForce = 10f; // Jump force
    public Transform groundCheck; // Position to check for ground
    public LayerMask groundLayer; // Layer of the ground
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Get input for left/right movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Move the character
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer); // Check if the character is on the ground

        if (isGrounded && Input.GetButtonDown("Jump")) // Jump when the player presses the jump button
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
