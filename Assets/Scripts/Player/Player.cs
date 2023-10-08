using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Awake()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "Coin"))
        {
            PlayerInventory.Instance.UpdateCoins();            
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag.Equals( "Enemy"))
        {
            playerHealth.Die();
        }
    }
}
