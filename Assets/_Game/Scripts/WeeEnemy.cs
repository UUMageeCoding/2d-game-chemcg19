using UnityEngine;

public class WeeEnemy : MonoBehaviour
{
    public Transform PlayerPosition;
    Vector2 directionPlayer;
    public float speed = 3f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPosition != null)
        {
            directionPlayer = (PlayerPosition.position - transform.position).normalized;
            Debug.Log(directionPlayer);
        }
        if (PlayerPosition != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPosition.position, speed * Time.deltaTime);
        }
    }
}
