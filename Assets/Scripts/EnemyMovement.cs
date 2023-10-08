using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    
    private Transform targetPlayer;

    private void Awake()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp (transform.rotation
            , Quaternion.LookRotation (targetPlayer.position - transform.position), rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * moveSpeed * Time.deltaTime;

    }
}
