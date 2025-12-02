using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class EnemyProximity : MonoBehaviour
{
    [SerializeField] private Transform newTarget; // Usually the enemy itself
    [SerializeField] private float triggerRadius = 2f; // Distance to trigger target change
    [SerializeField] private Animator animator; // Enemy's Animator

    private bool isAttacking;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }

    private void Update()
    {
        // Find all followers in the scene
        Follower[] followers = FindObjectsOfType<Follower>();
        bool followerClose = false;

        foreach (var follower in followers)
        {
            if (Vector2.Distance(transform.position, follower.transform.position) <= triggerRadius)
            {
                follower.SetTarget(newTarget);
                followerClose = true;
            }
        }

        // Animate enemy based on proximity
        if (animator != null)
        {
            if (followerClose)
            {
                animator.SetBool("isAttacking", true);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("isAttacking", false);
                animator.SetBool("isIdle", true);
            }
        }
    }
}
