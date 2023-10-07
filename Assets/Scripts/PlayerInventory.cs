using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int CollectedNumberOfCoins;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "Coin"))
        {
            CollectedNumberOfCoins++;
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag.Equals( "Enemy"))
        {
            
        }
        
        else if(other.gameObject.tag.Equals( "EnemyProjectile"))
        {
            
        }
    }
    
}
