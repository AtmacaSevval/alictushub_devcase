using System;
using UnityEngine;

public class EnemyShooting : BaseShooter
{
    [SerializeField] private int shootingRange;
    
    public static event Action<GameObject> OnEnemyEnteredField;
    public static event Action OnEnemyExitField;
    
    private EnemyAnimationManager animationManager;
    private EnemyHealth enemyHealth;
    
    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        animationManager = GetComponentInChildren<EnemyAnimationManager>();
    }

    protected override void Start()
    {
        base.Start();
        targetTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (enemyHealth.IsDead)
        {
            StopShooting();
        }

        CheckInRange();
    }

    private void CheckInRange()
    {
        if (Vector3.Distance(transform.position, targetTransform.position) < shootingRange)
        {
            isInTheField = true;
        }
        else
        {
            isInTheField = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Radius"))
        {
            animationManager.PlayEnteredFieldAnimation();
            OnEnemyEnteredField?.Invoke(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Radius"))
        {
            animationManager.StopEnteredFieldAnimation();
            OnEnemyExitField?.Invoke();

        }
    }
}
