using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] public float ShootSpeed;
    [SerializeField] public Transform SpawnPoint;
    [SerializeField] public GameObject Projectile;

    private bool _isInTheField = false;
    private GameObject _targetEnemy;

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
        _isInTheField = true;
        _targetEnemy = enemy;
    }
    
    private void Start()
    {
        InvokeRepeating("ShootEnemy", 1f, 2f);

    }
    
    void ShootEnemy(){

        if (_isInTheField && _targetEnemy != null){

            gameObject.transform.LookAt(_targetEnemy.transform);
            GameObject bullet = Instantiate(Projectile, SpawnPoint.position, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * ShootSpeed, ForceMode.Impulse);
        }

    }
    
}
