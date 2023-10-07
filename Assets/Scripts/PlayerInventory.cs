using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private int _collectedNumberOfCoins;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals( "Coin"))
        {
            UpdateCoinText();            
            Destroy(other.gameObject);
        }

        else if(other.gameObject.tag.Equals( "Enemy"))
        {
            //Destroy(gameObject);
        }
    }


    private void UpdateCoinText()
    {
        _collectedNumberOfCoins++;
        coinText.text = _collectedNumberOfCoins.ToString();
    }
}
