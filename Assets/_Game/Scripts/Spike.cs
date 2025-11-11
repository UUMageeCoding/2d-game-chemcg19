using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject triggerObject;
    public float speed = 2f;
    private bool isActive = false;

    void Update()
    {
        if (isActive)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && gameObject == triggerObject)
        {
            isActive = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isActive && collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            Debug.Log("You died.");
        }
    }
}