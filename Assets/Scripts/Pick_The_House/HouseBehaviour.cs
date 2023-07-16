using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseBehaviour : MonoBehaviour
{
    public int houseId;
    public Vector2 direction;
    
    void Start()
    {
        direction = Vector2.zero;
    }

    void Update()
    {
        Vector2 newPos = new Vector2(
            transform.position.x + direction.x * Time.deltaTime,
            transform.position.y + direction.y * Time.deltaTime
        );
        transform.position = newPos;

        if (transform.position.y >= 10f)
        {
            direction = Vector2.zero;
        }
    }
}
