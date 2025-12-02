
using UnityEngine;

public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float acceleration = 5f; // Controls easing
    [SerializeField] private float stopDistance = 0.5f;

    [Header("Idle Orbit Settings")]
    [SerializeField] private float orbitRadius = 0.3f;
    [SerializeField] private float orbitSpeed = 1f;

    private Vector2 velocity;
    private float orbitAngle;

    public Transform Target
    {
        get => target;
        set => target = value;
    }

    public void SetTarget(Transform newTarget)
    {
        if (newTarget != null)
            target = newTarget;
    }

    private void Update()
    {
        if (target == null) return;

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance > stopDistance)
        {
            // Smooth acceleration toward target
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 desiredVelocity = direction * speed;
            velocity = Vector2.Lerp(velocity, desiredVelocity, acceleration * Time.deltaTime);

            // Apply movement
            transform.position += (Vector3)(velocity * Time.deltaTime);

            // Flip based on movement direction
            if (Mathf.Abs(velocity.x) > 0.01f)
            {
                transform.localScale = new Vector3(Mathf.Sign(velocity.x) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            // Slow down smoothly
            velocity = Vector2.Lerp(velocity, Vector2.zero, acceleration * Time.deltaTime);
            transform.position += (Vector3)(velocity * Time.deltaTime);

            // Subtle orbit around target
            orbitAngle += orbitSpeed * Time.deltaTime;
            float orbitX = Mathf.Cos(orbitAngle) * orbitRadius;
            float orbitY = Mathf.Sin(orbitAngle) * orbitRadius;
            transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(orbitX, orbitY, 0), 0.05f);
        }
    }
}
