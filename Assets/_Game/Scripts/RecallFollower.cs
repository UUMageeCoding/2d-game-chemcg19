using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class RecallFollower : MonoBehaviour
{
    [SerializeField] private Transform newTarget2;
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
        RecallFollower[] players = Object.FindObjectsByType<RecallFollower>();

        foreach (var player in players)
        {
            if (Vector2.Distance(transform.position, player.transform.position) <= triggerRadius)
            {
                player.SetTarget(newTarget2);
            }
        }
    }
}