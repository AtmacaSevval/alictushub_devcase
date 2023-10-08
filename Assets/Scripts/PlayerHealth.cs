using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image healthBarFill;
    [SerializeField] private float maximumHealth = 10;
    
    private float currentHealth;
    private static event Action OnHealthDecreasedEvent;
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
    }
    
    void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maximumHealth;
    }
}