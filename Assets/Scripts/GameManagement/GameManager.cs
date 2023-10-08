using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{    
    public bool IsGameOver { get; private set; }

    public GameObject gameOverUI;

    private void Start()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
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
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        IsGameOver = false;
        gameOverUI.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
