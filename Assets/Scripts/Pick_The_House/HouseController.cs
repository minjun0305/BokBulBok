using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseController : MonoBehaviour
{
    [SerializeField] private HousePositionContainer housePosition;
    [SerializeField] private GameObject housePrefab;
    private PickTheHouseCore _gameCore;
    public int safeHouseID;
    private HouseBehaviour[] _houseList;

    private void Awake()
    {
        _gameCore = GetComponentInParent<PickTheHouseCore>();
        _houseList = new HouseBehaviour[3];
    }
    
    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            float houseXPos = i switch
            {
                0 => housePosition.houseX1,
                1 => housePosition.houseX2,
                2 => housePosition.houseX3,
                _ => 0f
            };

            Vector2 housePos = new Vector2(houseXPos, housePosition.houseY);
            GameObject generatedHouse = Instantiate(housePrefab, housePos, Quaternion.identity, transform);
            HouseBehaviour generatedHouseBehaviour = generatedHouse.GetComponent<HouseBehaviour>();

            generatedHouseBehaviour.houseId = i + 1;
            _houseList[i] = generatedHouseBehaviour;
            safeHouseID = _gameCore.SafeHouse;
        }
    }

    public void Blow()
    {
        foreach (HouseBehaviour house in _houseList)
        {
            if (house.houseId != safeHouseID)
            {
                house.direction = new Vector2(0f, 10f);
            }
        }
    }

    public void ProcessSuccessOrFailure(int index)
    {
        if (index == safeHouseID) _gameCore.Success();
        else _gameCore.Failure();
    }
}
