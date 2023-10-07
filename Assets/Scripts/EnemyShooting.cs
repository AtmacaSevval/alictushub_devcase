using System;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] public float ShootSpeed;
    [SerializeField] public Transform SpawnPoint;
    [SerializeField] public GameObject Projectile;

    private bool _isInTheField = false;
    private Transform _targetPlayer;
    
    public static event Action<GameObject> OnEnemyEnteredField;

    private void Awake()
    {
        _targetPlayer = GameObject.FindWithTag("Player").transform;

    }

    private void Start()
    {
        InvokeRepeating("ShootPlayer", 1f, 2f);

    }

    void ShootPlayer(){

        if (_isInTheField){

            gameObject.transform.LookAt(_targetPlayer.transform);
            GameObject bullet = Instantiate(Projectile, SpawnPoint.position, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * ShootSpeed, ForceMode.Impulse);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Radius"))
        {
            _isInTheField = true;
            OnEnemyEnteredField?.Invoke(gameObject);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Radius"))
        {
            _isInTheField = false;
        }
    }
}
