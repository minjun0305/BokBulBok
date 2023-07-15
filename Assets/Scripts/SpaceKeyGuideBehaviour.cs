using UnityEngine;
using UnityEngine.UI;

public class SpaceKeyGuideBehaviour : MonoBehaviour
{
    private bool _motionActivated = false;
    private float _elapsedTime = -1f;

    public Sprite[] sprites;
    
    public void SpaceKeyGuideStart()
    {
        gameObject.SetActive(true);
        _motionActivated = true;
        _elapsedTime = 0f;
    }

    public void SpaceKeyGuideStop()
    {
        gameObject.SetActive(false);
        _motionActivated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_motionActivated)
        {
            int idx = Mathf.FloorToInt(_elapsedTime * 2f) % 2;
            GetComponent<Image>().sprite = sprites[idx];

            _elapsedTime += Time.deltaTime;
        }
    }
}
