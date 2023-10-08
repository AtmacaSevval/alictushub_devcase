using UnityEngine;

public class BaseShooter : MonoBehaviour
{
    [SerializeField] protected float shootSpeed;
    [SerializeField] protected float shootingStartDelay;
    [SerializeField] protected float shootingInterval;

    [SerializeField] protected Transform spawnPointOfProjectile;
    [SerializeField] protected GameObject projectile;
    
    protected bool isInTheField = false;
    protected Transform targetTransform;

    protected virtual void Start()
    {
        StartShooting();    
    }
    private void StartShooting()
    {
        InvokeRepeating("ShootTarget", shootingStartDelay, shootingInterval);
    }
    protected void StopShooting()
    {
        CancelInvoke("ShootTarget");
    }

    protected void ShootTarget()
    {
        if (isInTheField && targetTransform != null)
        {
            transform.LookAt(targetTransform);
            
            GameObject bullet = Instantiate(projectile, spawnPointOfProjectile.position, transform.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * shootSpeed, ForceMode.Impulse);
        }
    }
}