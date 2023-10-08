using System;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform spawnPointOfProjectile;
    [SerializeField] private GameObject projectile;

    private bool isInTheField = false;
    private Transform targetPlayer;
    
    public static event Action<GameObject> OnEnemyEnteredField;

    private void Awake()
    {
        targetPlayer = GameObject.FindWithTag("Player").transform;

    }

    private void Start()
    {
        InvokeRepeating("ShootPlayer", 1f, 2f);

    }

    void ShootPlayer(){

        if (isInTheField){

            gameObject.transform.LookAt(targetPlayer.transform);
            
            GameObject bullet = Instantiate(projectile, spawnPointOfProjectile.position, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            
            bulletRigidbody.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Radius"))
        {
            isInTheField = true;
            OnEnemyEnteredField?.Invoke(gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Radius"))
        {
            isInTheField = false;
        }
    }
}
