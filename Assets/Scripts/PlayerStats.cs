using TMPro;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private TMP_Text coinText;
    private int collectedNumberOfCoins;
    
    [SerializeField] private TMP_Text numberOfEnemyKilledText;
    private int numberOfEnemyKilled;
    
    public void UpdateCoins()
    {
        collectedNumberOfCoins++;

        if (coinText != null)
        {
            coinText.text = collectedNumberOfCoins.ToString();
        }
    }
    
    public void UpdateKills()
    {
        numberOfEnemyKilled++;

        if (numberOfEnemyKilledText != null)
        {
            numberOfEnemyKilledText.text = numberOfEnemyKilled.ToString();
        }
    }
}
