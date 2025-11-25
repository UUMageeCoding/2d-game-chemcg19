using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private CameraFollow cameraFollow;

    void Start()
    {
        // Find the CameraFollow2D script in the scene
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If the player hits an object tagged "StopCamera", stop following
        if (collision.gameObject.CompareTag("StopCamera"))
        {
            if (cameraFollow != null)
                cameraFollow.StopFollowing();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Resume following when leaving the object
        if (collision.gameObject.CompareTag("StopCamera"))
        {
            if (cameraFollow != null)
                cameraFollow.ResumeFollowing();
        }
    }
}