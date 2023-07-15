using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private HousePositionContainer housePos;
    private PickTheHouseCore _gameCore;
    private Vector2 _direction;
    private Vector2 _destination;
    public bool ChoseHouse { get; private set; }

    private void Start()
    {
        ChoseHouse = false;
        transform.position = new Vector2(0f, -3f);
        _gameCore = GetComponentInParent<PickTheHouseCore>();
        _direction = Vector2.zero;
    }

    private void Update()
    {
        Vector2 nextPos = new Vector2(
            transform.position.x + _direction.x * Time.deltaTime,
            transform.position.y + _direction.y * Time.deltaTime
            );
        transform.position = nextPos;

        if (Vector2.Distance(transform.position, _destination) <= 1e-4)
            _direction = Vector2.zero;
    }

    public void GoIntoTheHouse(int index)
    {
        ChoseHouse = true;
        float destPosX = index switch
        {
            1 => housePos.houseX1,
            2 => housePos.houseX2,
            3 => housePos.houseX3,
            _ => 0f
        };

        _destination = new Vector2(destPosX, housePos.houseY);
        
        _gameCore.StopTimer();

        float xDist = _destination.x - transform.position.x;
        float yDist = _destination.y - transform.position.y;
        _direction = new Vector2(xDist, yDist);
    }

    public void ResetPlayer()
    {
        ChoseHouse = false;
        transform.position = new Vector2(0f, -3f);
        _direction = Vector2.zero;
        _destination = Vector2.zero;
    }
}
