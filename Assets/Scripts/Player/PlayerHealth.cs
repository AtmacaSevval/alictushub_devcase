using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private float maximumHealth = 10;
    
    private float currentHealth;
    private static event Action OnHealthDecreasedEvent;
    public static event Action OnPlayerDied;
    
    public bool IsDead { get; private set; }
    private PlayerAnimationManager animationManager;

    private void Awake()
    {
        animationManager = GetComponentInChildren<PlayerAnimationManager>();
    }
    
    private void Start()
    {
        currentHealth = maximumHealth;
    }

    private void OnEnable()
    {
        OnHealthDecreasedEvent += DecreaseHealth;
    }
    
    private void OnDisable()
    {
        OnHealthDecreasedEvent -= DecreaseHealth;
    }
    
    public static void OnHealthDecreased()
    {
        OnHealthDecreasedEvent?.Invoke();
    } 
    
    void DecreaseHealth()
    {
        currentHealth--;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        currentHealth = 0;
        UpdateHealthBar();
        
        animationManager.PlayDeathAnimation();
        OnPlayerDied?.Invoke();
    }

    void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maximumHealth;
    }
}