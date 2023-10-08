using TMPro;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private TMP_Text coinText;
    static int _collectedNumberOfCoins;
    
    [SerializeField] private TMP_Text numberOfEnemyKilledText;
    private int _numberOfEnemyKilled;
    
    private const string COIN_KEY = "CollectedCoins";
    
    private void Start()
    {
        LoadStats();
        UpdateCoinText();
        
        UpdateKillText();
    }
    
    private void LoadStats()
    {
        _collectedNumberOfCoins = PlayerPrefs.GetInt(COIN_KEY, 0);
    }
    public void UpdateCoins()
    {
        _collectedNumberOfCoins++;
        PlayerPrefs.SetInt(COIN_KEY, _collectedNumberOfCoins);
        
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = _collectedNumberOfCoins.ToString();
        }
    }

    public void UpdateKills()
    {
        _numberOfEnemyKilled++;
        UpdateKillText();
    }
    
    private void UpdateKillText()
    {
        if (numberOfEnemyKilledText != null)
        {
            numberOfEnemyKilledText.text = _numberOfEnemyKilled.ToString();
        }
    }
}
