using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] public Image HealthbarFill;

    public float _healthBarFullValue = 10;
    private float _healthBarCurrentValue;
    private static event Action OnHealthDecreasedEvent;
    private void Start()
    {
        _healthBarCurrentValue = _healthBarFullValue;
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
        _healthBarCurrentValue--;
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        HealthbarFill.fillAmount = _healthBarCurrentValue / _healthBarFullValue;
    }


}