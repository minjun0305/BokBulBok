using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simchung : MonoBehaviour
{
    public float speed = 300;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        float newX = rect.anchoredPosition.x;
        if (rect.anchoredPosition.y > -4000)
        {
            newX = Mathf.Clamp(cursorPos.x - 960, -520, 520);
        }
        rect.anchoredPosition = new Vector2(newX, rect.anchoredPosition.y - speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("colided");
        this.transform.parent.parent.GetComponentInParent<GameControl>().EndGameWith(0);

    }

    public void onTimeout()
    {
        int myChoice = 0;
        if (rect.anchoredPosition.x < -175)
        {
            myChoice = 1;
        }
        else if (rect.anchoredPosition.x < 175)
        {
            myChoice = 2;
        }
        else
        {
            myChoice = 3;
        }

        this.transform.parent.GetComponentInParent<GameCommonData>().returnValue = myChoice;
    }
}
