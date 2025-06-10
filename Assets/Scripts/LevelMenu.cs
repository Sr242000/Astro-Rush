using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        GameManager.Instance.LoadLevel(levelId);
    }
}
