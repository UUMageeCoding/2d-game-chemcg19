using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (safeObject == null)
        {
            Debug.LogWarning("Safeobject not assigned!");
            return;
        }

        float distance = Vector2.Distance(transform.position, safeObject.position);

        if (distance > safeDistance)
        {
            TakeDamage(damagePerSecond * Time.deltaTime);
        }

    }

    private void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log($"Player took {amount} damage. Health: {currentHealth}");
    }

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)currentHealth / maxHealth;
        }
    }

    private void Die()
    {
        Debug.Log("You died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
