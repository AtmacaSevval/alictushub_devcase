using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public int maxHealth = 1;
    private int currentHealth;
    private static event Action EnemyTakeDamage;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnEnable()
    {
        EnemyTakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        EnemyTakeDamage -= TakeDamage;
    }
    
    public static void OnTakeDamage()
    {
        EnemyTakeDamage?.Invoke();
    } 
    
    public void TakeDamage()
    {
        currentHealth --;

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
