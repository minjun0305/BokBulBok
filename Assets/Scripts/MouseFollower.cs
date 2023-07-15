using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CursorTracker : MonoBehaviour
{

    public Vector3 myPos;
    public Vector3 cursorPos;

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
        degree = Mathf.Clamp(degree, 30, 150);
        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, degree-90);
    }
}
