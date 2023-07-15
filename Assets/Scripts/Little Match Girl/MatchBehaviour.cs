using UnityEngine;

public class MatchBehaviour : MonoBehaviour
{
    private bool _isScratching;

    private int _scratchCount;
    private int _marchState;

    private float _initialTime;

    private GameObject _fireObjectSmall;
    private GameObject _fireObjectLarge;

    private const float _minX = -2.0f;
    private const float _maxX = 2.0f;
    private const float _minY = -3.0f;
    private const float _maxY = -1.8f;

    private const float _scratchFastTime = 0.1f;
    private const float _scratchSlowTime = 0.3f;

    public void LittleMarchGirlStart()
    {
        _isScratching = false;
        _scratchCount = 0;
        _marchState = 0;
        _initialTime = -1f;
        _fireObjectSmall = gameObject.transform.Find("MatchTipFireSmall").gameObject;
        _fireObjectLarge = gameObject.transform.Find("MatchTipFireLarge").gameObject;
        _fireObjectSmall.SetActive(false);
        _fireObjectLarge.SetActive(false);
    }

    public void LittleMarchGirlTimeover()
    {
        GetComponentInParent<GameCommonData>().returnValue = _marchState;
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
                else
                {
                    if (scratchingTime <= _scratchFastTime)
                    {
                        Debug.Log("ScratchFast");

                        _marchState = 2;
                        _fireObjectLarge.SetActive(true);
                        _fireObjectSmall.SetActive(false);

                    }
                    else if (scratchingTime <= _scratchSlowTime)
                    {
                        Debug.Log("ScratchSlow");

                        _marchState = 1;
                        _fireObjectSmall.SetActive(true);
                        _fireObjectLarge.SetActive(false);
                    }
                }
            }

            _isScratching = false;
        }
    }
}
