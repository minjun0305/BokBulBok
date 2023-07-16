using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    public GameObject backgroundGameObject;
    public GameObject RetryButtonGameObject;
    public GameObject GotoMainGameObject;

    public Sprite[] backgroundSprites;

    private void Start()
    {
        Debug.Log("Current game ending value: " + GameManager.gm.GetGameEnding());
    }

    public void SetBackgroundImage(int idx)
    {
        backgroundGameObject.GetComponent<Image>().sprite = backgroundSprites[idx];
    }

    public void RetryButtonClick()
    {
        GameManager.gm.StartGame();
    }

    public void GotoMainButton()
    {
        GameManager.gm.MainScreen();
    }

}
