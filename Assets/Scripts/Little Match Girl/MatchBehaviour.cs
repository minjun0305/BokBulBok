using UnityEngine;

public class MatchBehaviour : MonoBehaviour
{
    private bool _isScratching;

    private int _scratchCount;
    private int _matchState;

    private float _initialTime;

    private GuideImageBehaviour _guideImageBehaviour;

    private const float _minX = -2.0f;
    private const float _maxX = 2.0f;
    private const float _minY = -3.0f;
    private const float _maxY = -1.8f;

    private const float _scratchFastTime = 0.1f;
    private const float _scratchSlowTime = 0.3f;

    public GameObject FireObjectSmall;
    public GameObject FireObjectLarge;
    public GameObject MouseGuideGameObject;

    public void LittleMatchGirlStart()
    {
        _isScratching = false;
        _scratchCount = 0;
        _matchState = 0;
        _initialTime = -1f;
        _guideImageBehaviour = MouseGuideGameObject.GetComponent<GuideImageBehaviour>();
        _guideImageBehaviour.GuideAnimationStart();
        FireObjectSmall.SetActive(false);
        FireObjectLarge.SetActive(false);
    }

    public void LittleMatchGirlTimeover()
    {
        _guideImageBehaviour.GuideAnimationStop();
        GetComponentInParent<GameCommonData>().returnValue = _matchState;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 matchPos = new(mousePos.x, mousePos.y, 0f);
        transform.position = matchPos;

        if (matchPos.x >= _minX && matchPos.x <= _maxX &&
            matchPos.y >= _minY && matchPos.y <= _maxY)
        {
            if (!_isScratching)
            {
                _isScratching = true;
                _initialTime = Time.time;
            }
        }
        else
        {
            if (_isScratching && matchPos.x < _minX)
            {
                float scratchingTime = Time.time - _initialTime;
                Debug.Log("scratching time: " + scratchingTime);

                if (_scratchCount < 3)
                {
                    if (scratchingTime <= _scratchSlowTime)
                    {
                        _scratchCount++;
                        Debug.Log("scratch count: " + _scratchCount);
                    }
                }
                else if (_matchState == 0)
                {
                    if (scratchingTime <= _scratchFastTime)
                    {
                        Debug.Log("ScratchFast");

                        _matchState = 1;
                        FireObjectLarge.SetActive(true);
                        FireObjectSmall.SetActive(false);

                    }
                    else if (scratchingTime <= _scratchSlowTime)
                    {
                        Debug.Log("ScratchSlow");

                        _matchState = 2;
                        FireObjectSmall.SetActive(true);
                        FireObjectLarge.SetActive(false);
                    }
                }
            }

            _isScratching = false;
        }
    }
}
