using UnityEngine;

public class PauseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Instance.CurrentState == GameState.Paused)
            {
                GameManager.Instance.ResumeGame();
            }
            else if (GameManager.Instance.CurrentState == GameState.Playing)
            {
                GameManager.Instance.PauseGame();
            }
        }
    }

    // These can be used by UI buttons
    public void ResumeGame()
    {
        GameManager.Instance.ResumeGame();
    }

    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
}
