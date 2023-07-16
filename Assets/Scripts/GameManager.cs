using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int gameEnding = -1;
    
    public static GameManager gm;

    public void SetGameEnding(int value)
    {
        gameEnding = value;
    }

    public int GetGameEnding()
    { 
        return gameEnding;
    }

    private void Awake()
    {
        gm = this;
    }

    public void StartGame()
    {
        gameEnding = -1;
        SceneManager.LoadScene("Scenes/MainScene");
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Scenes/StartScene");
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
