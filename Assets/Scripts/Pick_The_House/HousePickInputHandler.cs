using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePickInputHandler : MonoBehaviour
{
    [SerializeField] private HousePositionContainer housePositions;
    private HouseController _houseControl;
    private PlayerBehaviour _playerControl;

    private void Start()
    {
        _houseControl = GetComponentInChildren<HouseController>();
        _playerControl = GetComponentInChildren<PlayerBehaviour>();
        StartCoroutine("ForceEndGame");
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            for (int i = 1; i <= 3; i++)
            {
                Vector2 housePosition = i switch
                {
                    1 => new Vector2(housePositions.houseX1, housePositions.houseY),
                    2 => new Vector2(housePositions.houseX2, housePositions.houseY),
                    3 => new Vector2(housePositions.houseX2, housePositions.houseY),
                    _ => Vector2.zero
                };

                if (clickPosition.x <= housePosition.x + 0.5f && clickPosition.x >= housePosition.x - 0.5f &&
                    clickPosition.y <= housePosition.y + 0.5f && clickPosition.y >= housePosition.y - 0.5f &&
                    !_playerControl.ChoseHouse)
                {
                    StopCoroutine("ForceEndGame");
                    StartCoroutine(ProcessGameFlow(i));
                }
            }
        }
    }

    private IEnumerator ProcessGameFlow(int index)
    {
        _playerControl.GoIntoTheHouse(index);
        yield return new WaitForSeconds(1);

        _houseControl.Blow();
        yield return new WaitForSeconds(1);
        
        _houseControl.ProcessSuccessOrFailure(index);
    }

    private IEnumerator ForceEndGame()
    {
        yield return new WaitForSeconds(5);
        _playerControl.ChoseHouse = true;
        _houseControl.Blow();
        yield return new WaitForSeconds(1);
        
        _houseControl.ProcessSuccessOrFailure(-1);
    }
}
