using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public float range = 10.0f;
    [SerializeField] public float bulletImpulse= 20.0f;
    
    public Rigidbody projectile;

    public float shotDelayTime;
    public float shotInterval;
    
    private bool isInThefield = true;
    void Start(){
        
        InvokeRepeating("Shoot", shotDelayTime, shotInterval);
    }
    
    void Update() {
 
        
    }
    void Shoot(){
 
        if (isInThefield){
 
            Rigidbody bullet = Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward*bulletImpulse, ForceMode.Impulse);
        }
 
 
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy (other.gameObject);

        }
    }
}
