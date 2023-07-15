using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkarosDiveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Clamp(2 * (420-cursorPos.x) +440, -1080, 0), Mathf.Clamp(2 * -cursorPos.y + 350, -900, 0));

    }
}
