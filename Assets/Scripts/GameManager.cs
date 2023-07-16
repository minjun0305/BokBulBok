using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int GameEnding = -1;
    
    public static GameManager gm;

    public void SetGameEnding(int value)
    {
        GameEnding = value;
    }

    public int GetGameEnding()
    { 
        return GameEnding;
    }

    private void Awake()
    {
        gm = this;
    }

    public void StartGame()
    {
        GameEnding = -1;
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Scenes/TitleScene");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameoverScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
