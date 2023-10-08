using TMPro;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    [SerializeField] private TMP_Text coinText;
    static int _collectedNumberOfCoins;
    
    [SerializeField] private TMP_Text numberOfEnemyKilledText;
     static int _numberOfEnemyKilled;
    
    private const string COIN_KEY = "CollectedCoins";
    private const string KILL_KEY = "EnemyKilled";
    
    private void Start()
    {
        LoadStats();
        UpdateCoinText();
        UpdateKillText();
    }
    
    private void LoadStats()
    {
        _collectedNumberOfCoins = PlayerPrefs.GetInt(COIN_KEY, 0);
        _numberOfEnemyKilled = PlayerPrefs.GetInt(KILL_KEY, 0);
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
        PlayerPrefs.SetInt(KILL_KEY, _numberOfEnemyKilled);
        
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
