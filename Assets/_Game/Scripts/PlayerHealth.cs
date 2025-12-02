using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damagePerSecond = 5;

    public Transform safeObject;
    public float safeDistance = 7f;

    [Header("UI")]
    public Slider healthBar;

    [Header("Enemy Damage")]
    public int collisionDamage = 20; // damage taken when colliding with enemy

    [Header("Effects")]
    public ParticleSystem hitEffect; // assign prefab in Inspector


    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    void Update()
    {
        if (safeObject == null)
        {
            Debug.LogWarning("Safeobject not assigned!");
            return;
        }

        float distance = Vector3.Distance(transform.position, safeObject.position);

        if (distance > safeDistance)
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    private void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyDamage(int damage)
    {
        TakeDamage(damage); // reuse float version
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    private void Die()
    {
        Debug.Log("You died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //  Trigger with enemy (if enemy collider is set as trigger)
    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.CompareTag("Enemy"))
        {
        TakeDamage(collisionDamage);
            Debug.Log("Player took damage! Current health: " + currentHealth);
        
            if (hitEffect != null)
            {
            // Spawn particle effect at player’s position
                Instantiate(hitEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
