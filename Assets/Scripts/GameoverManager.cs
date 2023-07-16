using UnityEngine;
using UnityEngine.UI;

public class GameoverManager : MonoBehaviour
{
    public GameObject BackgroundGameObject;
    public GameObject RetryButtonGameObject;
    public GameObject GotoMainGameObject;

    public Sprite[] backgroundSprites;

    private void Start()
    {
        Debug.Log("Current game ending value: " + GameManager.gm.GetGameEnding());
    }

    public void SetBackgroundImage(int idx)
    {
        BackgroundGameObject.GetComponent<Image>().sprite = backgroundSprites[idx];
    }

    public void RetryButtonClick()
    {
        GameManager.gm.StartGame();
    }

    public void GotoTitleButton()
    {
        GameManager.gm.MainScreen();
    }

}
