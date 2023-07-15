using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkarosDivePlayer : MonoBehaviour
{
    public float fakeZ = 4000.0f;
    public float speed = 300.0f;
    public float randomSeed = 0;
    // Start is called before the first frame update
    public void SetRandom()
    {
        randomSeed = Random.Range(0, 360);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z);
        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Clamp(2 * (cursorPos.x-420), 100, 2060), Mathf.Clamp(2 * cursorPos.y, 100, 1700));
        fakeZ -= speed * Time.deltaTime;
    }
}
