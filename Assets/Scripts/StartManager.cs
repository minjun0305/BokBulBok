using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;

    public void StartButtonClick()
    {
        GameManager.gm.StartGame();
    }

    public void HowToPlayButtonClick()
    {
        howToPlayPanel.SetActive(true);
    }

    public void HowToPlayExitButtonClick()
    {
        howToPlayPanel.SetActive(false);
    }

    public void CreditsButtonClick()
    {
        creditsPanel.SetActive(true);
    }

    public void CreditsExitButtonClick()
    {
        creditsPanel.SetActive(false);
    }

    public void QuitButtonClick()
    {
        GameManager.gm.QuitGame();
    }
}
