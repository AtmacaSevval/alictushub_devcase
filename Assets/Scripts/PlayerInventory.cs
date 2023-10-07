using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    private int _collectedNumberOfCoins;
    
    [SerializeField] private TMP_Text numberOfEnemyKilledText;
    private int _numberOfEnemyKilled;
    
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
    
    private void UpdateKillText()
    {
        _numberOfEnemyKilled++;
        numberOfEnemyKilledText.text = _numberOfEnemyKilled.ToString();
    }
}
