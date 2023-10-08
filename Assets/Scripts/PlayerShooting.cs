using UnityEngine;

public class PlayerShooting : BaseShooter
{
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