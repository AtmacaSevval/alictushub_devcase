using System;
using UnityEngine;

public class PlayerShooting : BaseShooter
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        EnemyShooting.OnEnemyEnteredField += HandleEnemyEnteredField;
        EnemyShooting.OnEnemyExitField += HandleEnemyExitField;

    }

    private void OnDisable()
    {
        EnemyShooting.OnEnemyEnteredField -= HandleEnemyEnteredField;
        EnemyShooting.OnEnemyExitField -= HandleEnemyExitField;

    }

    private void Update()
    {
        if (playerHealth.IsDead)
        {
            StopShooting();
        }
    }

    private void HandleEnemyEnteredField(GameObject enemy)
    {
        isInTheField = true;
        targetTransform = enemy.transform;
    }
    
    private void HandleEnemyExitField()
    {
        isInTheField = false;
        targetTransform = null;
    }
}