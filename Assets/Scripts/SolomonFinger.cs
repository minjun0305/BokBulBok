using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolomonFinger : MonoBehaviour
{
    public Vector3 myPos;
    public Vector3 cursorPos;
    public int myChoice;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        //myPos =
    }

    // Update is called once per frame
    void Update()
    {
        myPos = Camera.main.WorldToScreenPoint(this.transform.position);
        cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        float degree = Mathf.Atan2(cursorPos.y - myPos.y, cursorPos.x - myPos.x) * Mathf.Rad2Deg;
        
        if (degree <= -90)
        {
            degree = 149.9f;
        }
        else if (degree < 30)
        {
            degree = 30;
        }
        else if (degree >= 150)
        {
            degree = 149.9f;
        }
        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, degree - 90);
        myChoice = Mathf.FloorToInt(degree - 30) / 40 + 1;
    }

    public void onTimeout()
    {
        this.GetComponentInParent<GameCommonData>().returnValue = myChoice;
    }
}
