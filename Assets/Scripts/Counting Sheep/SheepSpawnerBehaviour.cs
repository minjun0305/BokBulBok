using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class SheepSpawnerBehaviour : MonoBehaviour
{
    private bool _hasSucceed;
    
    private int _sheepPassState; // 0: Ready, 1: Passing, 2: Passed
    private int _sheepCountCurrent;
    private int _sheepCountTotal;

    private float _elapsedTime;

    private TMP_Text _guideText;

    public int[] choices = { 9, 10, 11 };

    public GameObject sheepViewAreaGameObject;
    public GameObject sheepPrefab;

    public List<GameObject> _buttonCountGameobjects = new();

    public void CountButtonSelect(int choice)
    {
        Debug.Log("Your choice: " + choices[choice]);
        if (choices[choice] == _sheepCountTotal)
        {
            _guideText.text = "정답!";
            _hasSucceed = true;
        }
        else
        {
            _guideText.text = "오답!";
            _hasSucceed = false;
        }
    }

    public void CountingSheepStart()
    {
        _hasSucceed = false;
        _sheepPassState = 0;
        _sheepCountCurrent = 0;
        _sheepCountTotal = choices[Random.Range(0, 2)];
        Debug.Log("Sheep total count: " + _sheepCountTotal);
        _elapsedTime = 0f;

        foreach (GameObject obj in _buttonCountGameobjects)
        {
            obj.SetActive(false);
        }
        _guideText = GameObject.Find("GuideText").GetComponent<TMP_Text>();
    }

    public void CountingSheepTimeover()
    {

        transform.parent.parent.gameObject.GetComponent<GameControl>().EndGameWith(_hasSucceed ? 1 : 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_sheepPassState)
        {
            case 0:
                if (_elapsedTime >= 1f)
                {
                    _elapsedTime = 0f;
                    _sheepPassState = 1;
                }
                break;
            case 1:
                if (_elapsedTime >= 2f / _sheepCountTotal * _sheepCountCurrent)
                {
                    if (_sheepCountCurrent < _sheepCountTotal)
                    {
                        float movingTime = Random.Range(0.8f, 2f);
                        float initialPosX = Random.Range(-6.8f, -7.2f);
                        float initialPosY = Random.Range(-3f, 1f);
                        float finalPosX = Random.Range(6.8f, 7.2f);
                        float finalPosY = Random.Range(-3f, 1f);
                        GameObject sheepInstance = Instantiate(sheepPrefab, new Vector3(initialPosX, initialPosY, 0f), Quaternion.identity);

                        sheepInstance.transform.SetParent(sheepViewAreaGameObject.transform, false);
                        sheepInstance.GetComponent<SheepBehaviour>().SheepMoveStart(movingTime, new Vector3(initialPosX, initialPosY, 0f), new Vector3(finalPosX, finalPosY, 0f));
                        _sheepCountCurrent++;
                    }

                    if (_elapsedTime >= 4f)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            GameObject obj = _buttonCountGameobjects[i];

                            obj.GetComponentInChildren<TMP_Text>().text = choices[i].ToString();
                            obj.SetActive(true);
                        }
                        _sheepPassState = 2;
                    }
                }
                break;
            case 2:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        _elapsedTime += Time.deltaTime;
    }
}
