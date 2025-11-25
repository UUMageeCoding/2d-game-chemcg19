using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Follow Settings")]
    [SerializeField] private Transform target;
    [Header("Follow settings")]
    public float smoothSpeed = 5f;
    public Vector3 offset;

    private bool canFollow = true; // Controls whether the camera follows

    void LateUpdate()
    {
        if (target == null) return;

        if (canFollow)
        {
            // Smoothly move camera towards player's position + offset
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }

    /// <summary>
    /// Call this method to stop the camera from following.
    /// </summary>
    public void StopFollowing()
    {
        canFollow = false;
    }

    /// <summary>
    /// Call this method to resume following.
    /// </summary>
    public void ResumeFollowing()
    {
        canFollow = true;
    }
}