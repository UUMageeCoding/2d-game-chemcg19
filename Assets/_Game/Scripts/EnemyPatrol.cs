using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform pointA;          // First patrol point
    public Transform pointB;          // Second patrol point
    public float speed = 2f;          // Movement speed

    [Header("Combat Settings")]
    public int damage = 20;

    private Rigidbody2D rb;
    private Vector2 targetPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Validate patrol points
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Patrol points not assigned in the Inspector.");
            enabled = false;
            return;
        }

        targetPosition = pointB.position; // Start moving towards pointB
    }

    void FixedUpdate()
    {
        // Move towards the target position
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        // Flip sprite depending on direction
        if (spriteRenderer != null)
        {
            if (newPosition.x < rb.position.x)
                spriteRenderer.flipX = true;   // facing left
            else if (newPosition.x > rb.position.x)
                spriteRenderer.flipX = false;  // facing right
        }

        // Check if we reached the target
        if (Vector2.Distance(rb.position, targetPosition) < 0.05f)
        {
            // Switch target
            targetPosition = (targetPosition == (Vector2)pointA.position) ? pointB.position : pointA.position;
        }
    }
}
