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
    }


    public void Success()
    {
        gameControl.GetComponent<GameControl>().EndGameWith(4);
    }


    public void Failure()
    {
        gameControl.GetComponent<GameControl>().EndGameWith(5);
    }
}
