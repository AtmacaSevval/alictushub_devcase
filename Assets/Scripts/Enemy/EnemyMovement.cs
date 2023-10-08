using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    private Transform targetPlayer;
    private EnemyHealth enemyHealth;

    private void Awake()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform;
        enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (enemyHealth.IsDead) return;

        transform.rotation = Quaternion.Slerp (transform.rotation
            , Quaternion.LookRotation (targetPlayer.position - transform.position), rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
}
