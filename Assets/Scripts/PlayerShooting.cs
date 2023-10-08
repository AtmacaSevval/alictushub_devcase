using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float shootSpeed;
    [SerializeField] private Transform spawnPointOfProjectile;
    [SerializeField] private GameObject projectile;

    private bool isInTheField = false;
    private GameObject targetEnemy;

    private void Start()
    {
        InvokeRepeating("ShootEnemy", 1f, 2f);

    }
    private void OnEnable()
    {
        EnemyShooting.OnEnemyEnteredField += HandleEnemyEnteredField;
    }

    private void OnDisable()
    {
        EnemyShooting.OnEnemyEnteredField -= HandleEnemyEnteredField;
    }

    private void HandleEnemyEnteredField(GameObject enemy)
    {
        isInTheField = true;
        targetEnemy = enemy;
    }
    
    void ShootEnemy(){

        if (isInTheField && targetEnemy != null){

            gameObject.transform.LookAt(targetEnemy.transform);
            
            GameObject bullet = Instantiate(projectile, spawnPointOfProjectile.position, transform.rotation);
            
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
        }

    }
    
}
