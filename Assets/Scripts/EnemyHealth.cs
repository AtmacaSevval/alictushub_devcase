using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int currentHealth;
    
    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage()
    {
        currentHealth --;

        currentHealth = Mathf.Max(currentHealth, 0);

        if (currentHealth == 0)
        {
            Die();
            
            PlayerInventory.Instance.UpdateKills();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
