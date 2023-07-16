using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float speed;
    public float degree;

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

        this.GetComponent<RectTransform>().rotation = Quaternion.Euler(0, 0, degree);
    }
}
