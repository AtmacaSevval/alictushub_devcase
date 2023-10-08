using UnityEngine;

public class Player : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "Coin"))
        {
            PlayerInventory.Instance.UpdateCoins();            
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag.Equals( "Enemy"))
        {
            //Destroy(gameObject);
        }
    }
}
