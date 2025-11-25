using UnityEngine;

/// <summary>
/// Makes an object follow a target in 2D space.
/// </summary>
public class Follower : MonoBehaviour
{
    [SerializeField] private Transform target; // Current target to follow
    [SerializeField] private float speed = 3f; // Movement speed

    public string triggerObjectTag = "Activator";
    public bool follow = true;

    /// <summary>
    /// Sets a new target for the follower.
    /// </summary>
    public void SetTarget(Transform newTarget)
    {
        if (newTarget != null)
            target = newTarget;
    }

    private void Update()
    {
        if (target == null) return;

        // Move towards the target
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
