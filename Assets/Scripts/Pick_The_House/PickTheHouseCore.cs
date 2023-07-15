using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickTheHouseCore : MonoBehaviour
{
    private GameObject gameControl;
    private int _count;
    public int SafeHouse { get; private set; }

    private void Start()
    {
        gameControl = GetComponentInParent<GameControl>().gameObject;
        _count = 0;
        SafeHouse = Random.Range(0, 4);
        StartCoroutine("SetSingleTimeOut");
    }

    private IEnumerator SetSingleTimeOut()
    {
        yield return new WaitForSeconds(5);
        gameControl.GetComponent<GameControl>().EndGameWith(5);
    }

    public void Success()
    {
        StopCoroutine("SetSingleTimeOut");
        gameControl.GetComponent<GameControl>().EndGameWith(4);
    }

    public void StopTimer()
    {
        StopCoroutine("SetSingleTimeOut");
    }

    public void Failure()
    {
        _count++;
        if (_count >= 3) gameControl.GetComponent<GameControl>().EndGameWith(5);
        else
        {
            SafeHouse = Random.Range(0, 4);
            HouseController _houseController = GetComponentInChildren<HouseController>();
            PlayerBehaviour _player = GetComponentInChildren<PlayerBehaviour>();
            
            _houseController.safeHouseID = SafeHouse;
            _houseController.ResetHousePosition();
            _player.ResetPlayer();
            StartCoroutine("SetSingleTimeOut");
        }
    }
}
