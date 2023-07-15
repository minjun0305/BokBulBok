using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<GameObject> gameList;
    public GameObject nameText;
    public GameObject timeBar;
    bool isGameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        ;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning)
        {
            StartNewGame();
        }

    }

    private void StartNewGame()
    {
        StartGame(Random.Range(0, gameList.Count));
    }

    private void StartGame(int id)
    {
        GameObject currGame = Instantiate(gameList[id], new Vector3(0, 0, 0), Quaternion.identity);
        currGame.transform.SetParent(this.transform, false);
        GameCommonData data = currGame.GetComponent<GameCommonData>(); 
        nameText.GetComponent<TextMeshProUGUI>().text = data.gameName;
        timeBar.GetComponent<TimeBarControl>().SetTimer(data.timeLimit);

        if (data.initFunc != null)
        {
            data.initFunc.Invoke();
        }
        isGameRunning = true;
    }
    public void EndGameWith(int ChoosenItem) // 0(fail), 1,2,3
    {
        print(ChoosenItem);
        isGameRunning = false;
        timeBar.GetComponent<TimeBarControl>().EndTimer();
        GameObject currGame = this.GetComponentInChildren<GameCommonData>().gameObject;
        currGame.SetActive(false);
    }

    public void Timeout()
    {
        print("timeout");
        GameCommonData data = this.GetComponentInChildren<GameCommonData>();
        data.Timeover();
    }
    
}
