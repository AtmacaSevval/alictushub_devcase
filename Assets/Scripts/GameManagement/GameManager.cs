using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{    
    public bool IsGameOver { get; private set; }

    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDied += EndGame;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDied -= EndGame;
    }
    
    private void EndGame()
    {
        IsGameOver = true;
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        IsGameOver = false;
        gameOverUI.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
