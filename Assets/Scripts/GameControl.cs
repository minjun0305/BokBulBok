using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public List<GameObject> gameList;
    public GameObject nameText;
    public GameObject timeBar;
    public GameObject coverObject;
    public GameObject successBG;
    public GameObject garbageStorage;
    bool isGameRunning = false;

    private DisburbTheWitch witchData;

    // Start is called before the first frame update
    void Start()
    {
        witchData = this.GetComponent<DisburbTheWitch>();
    }

    // Update is called once per frame
    void Update()
    {/*
        if (!isGameRunning)
        {
            StartNewGame();
        }*/
    }

    public void StartNewGame()
    {
        StartGame(Random.Range(0, gameList.Count));
    }

    private void StartGame(int id)
    {
        if (witchData.life <= 0)
        {
            GameManager.gm.GameOver();
        }
        GameObject currGame = Instantiate(gameList[id], new Vector3(0, 0, 0), Quaternion.identity);
        currGame.transform.SetParent(this.transform, false);
        GameCommonData data = currGame.GetComponent<GameCommonData>(); 
        nameText.GetComponent<TextMeshProUGUI>().text = data.gameName;
        timeBar.GetComponent<TimeBarControl>().SetTimer(data.timeLimit);
        int newIndex = witchData.GetNextIndex();
        data.itemInfo.Add(witchData.oa[newIndex]);
        data.itemInfo.Add(witchData.ob[newIndex]);
        data.itemInfo.Add(witchData.oc[newIndex]);

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
        if (garbageStorage.transform.childCount > 0)
        {
            Destroy(garbageStorage.transform.GetChild(0).gameObject);
        }
        GameObject currGame = this.GetComponentInChildren<GameCommonData>().gameObject;
        currGame.transform.SetParent(garbageStorage.transform);
        currGame.SetActive(false);

        if (ChoosenItem > 0)
        {
            witchData.life--;
            GameObject newItem;
            switch (ChoosenItem)
            {
                case 1:
                    newItem = witchData.oa[witchData.currIndex];
                    break;
                case 2:
                    newItem = witchData.ob[witchData.currIndex];
                    break;
                case 3:
                default:
                    newItem = witchData.oc[witchData.currIndex];
                    break;
            }/*
            newItem = Instantiate(newItem, new Vector3(0, 0, 0), Quaternion.identity);
            newItem.transform.parent = successBG.transform;*/
        }
        else
        {
            witchData.life= Mathf.Clamp(witchData.life+1, 0, 99);
        }
        coverObject.GetComponent<CoverFader>().startCover(ChoosenItem > 0);
    }

    public void Timeout()
    {
        print("timeout");
        GameCommonData data = this.GetComponentInChildren<GameCommonData>();
        data.Timeover();
    }
    
}
