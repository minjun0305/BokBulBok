using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimchungBackground : MonoBehaviour
{
    RectTransform rect;
    RectTransform rectSimchung;
    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
        rectSimchung = this.GetComponentsInChildren<Simchung>()[0].GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x,Mathf.Clamp(-500-rectSimchung.anchoredPosition.y, 0, 3100));
    }
}
