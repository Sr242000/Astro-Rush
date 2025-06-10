using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameState CurrentState { get; private set; } = GameState.MainMenu;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1); // You can use string names too
        CurrentState = GameState.Playing;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        CurrentState = GameState.Paused;
        UIManager.Instance.ShowPauseMenu(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        CurrentState = GameState.Playing;
        UIManager.Instance.ShowPauseMenu(false);
    }

    public void EndGame()
    {
        CurrentState = GameState.GameOver;
        UIManager.Instance.ShowGameOverScreen();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene("Level " + levelId);
        CurrentState = GameState.Playing;
    }
}
