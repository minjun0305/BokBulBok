using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SimchungBird : MonoBehaviour
{
    public int maxPos = 520;
    public int speed = 30;

    RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + rect.localScale.x * speed * Time.deltaTime, rect.anchoredPosition.y);
        if (rect.anchoredPosition.x * rect.localScale.x > maxPos)
        {
            rect.localScale = new Vector3(rect.localScale.x * -1, 1, 1);
        }
    }
}
