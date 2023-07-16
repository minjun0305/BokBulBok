using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWiggle : MonoBehaviour
{
    public float posX;
    public float posY;
    public float degree;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        degree += speed * Time.deltaTime;
        while (degree > 360.0f)
            degree -= 360.0f;

        while (degree < -360.0f)
            degree += 360.0f;

        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, posY + 5 * Mathf.Sin(degree));

    }
}
