using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 1;
    private int currentHealth;
    
    private EnemyAnimationManager animationManager;
    
    public bool IsDead { get; private set; }

    private void Awake()
    {
        animationManager = GetComponentInChildren<EnemyAnimationManager>();
    }
    
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
        IsDead = true;

        animationManager.PlayDeathAnimation();
        Destroy(gameObject, 2f);

    }
}
