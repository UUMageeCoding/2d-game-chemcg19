using UnityEngine;

/// <summary>
/// When the enemy gets close to the follower, it changes the follower's target.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class EnemyProximity : MonoBehaviour
{
    [SerializeField] private Transform newTarget; // The new target to assign (e.g., the enemy itself)

    [SerializeField] private float triggerRadius = 2f; // Distance to trigger target change

    private void OnDrawGizmosSelected()
    {
        // Draw detection radius in editor
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }

    private void Update()
    {
        // Find all followers in the scene
        Follower[] followers = FindObjectsOfType<Follower>();

        foreach (var follower in followers)
        {
            if (Vector2.Distance(transform.position, follower.transform.position) <= triggerRadius)
            {
                follower.SetTarget(newTarget);
            }
        }
    }
}
