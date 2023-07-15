using TMPro;
using UnityEngine;

public class AvoidingHunterBehaviour : MonoBehaviour
{
    private bool _keyPressed;

    private float _elapsedTime;

    public GameObject guideTextGameObject;
    public GameObject hunterGameObject;
    
    public void AvoidingHunterStart()
    {
        _keyPressed = false;
        _elapsedTime = 0f;
    }

    public void AvoidingHunterTimeover()
    {
        GetComponentInParent<GameCommonData>().returnValue = !_keyPressed ? 1 : 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_keyPressed)
        {
            if (Input.anyKeyDown)
            {
                guideTextGameObject.GetComponent<TMP_Text>().text = "µéÄ×´Ù!";
                hunterGameObject.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
                _keyPressed = true;
            }
            else
            {
                Vector3 newScale = hunterGameObject.GetComponent<RectTransform>().localScale;
                newScale.x = (Mathf.FloorToInt(_elapsedTime / 0.5f) % 2 == 0) ? 1f : -1f;
                hunterGameObject.GetComponent<RectTransform>().localScale = newScale;
            }

            _elapsedTime += Time.deltaTime;
        }
    }
}
