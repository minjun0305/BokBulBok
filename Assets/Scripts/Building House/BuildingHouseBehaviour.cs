using TMPro;
using UnityEngine;

public class BuildingHouseBehaviour : MonoBehaviour
{
    private bool _roofMovingDirection;  // False: Left, True: Right

    private int _roofResult;
    
    private float _roofState;   // 0: Moving, 1: Falling, 2: Result
    private float _roofPosX;
    private float _elapsedTime;

    private TimeBarControl _timeBarControl;
    private TMP_Text _guideText;
    private PiggyBehaviour _piggyBehaviour;

    private const float _roofInitialPosY = 1f;
    private const float _roofFinalPosY = -0.5f;
    private const float _roofPosRange = 3f;
    private const float _roofMovingSpeed = 10f;
    private const float _roofFallingTime = 0.5f;

    public GameObject roofGameObject;
    
    public void BuildingHouseStart()
    {
        _roofMovingDirection = false;
        _roofState = 0;
        GetComponentInChildren<GuideImageBehaviour>().GuideAnimationStart();
        roofGameObject.transform.position = new Vector3(0f, _roofInitialPosY, 0f);
        _timeBarControl = transform.parent.gameObject.transform.parent.gameObject.GetComponentInChildren<TimeBarControl>();
        _guideText = GetComponentInChildren<TMP_Text>();
        _piggyBehaviour = GetComponentInChildren<PiggyBehaviour>();
        _piggyBehaviour.SetImage(0);
    }

    public void BuildingHouseTimeover()
    {
        GetComponentInParent<GameCommonData>().returnValue = _roofResult;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_roofState)
        {
            case 0: // Moving
                _roofPosX += _roofMovingSpeed * Time.deltaTime * (_roofMovingDirection ? 1 : -1);
                if (_roofMovingDirection && _roofPosX >= _roofPosRange)
                {
                    _roofMovingDirection = false;
                }
                else if (!_roofMovingDirection && _roofPosX <= -_roofPosRange)
                {
                    _roofMovingDirection = true;
                }
            
                roofGameObject.transform.position = new Vector3(_roofPosX, _roofInitialPosY, 0f);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _roofState = 1;
                    _elapsedTime = 0f;
                    _timeBarControl.PauseTimer();
                    GetComponentInChildren<GuideImageBehaviour>().GuideAnimationStop();
                }
                break;
            case 1: //Falling
                if (_elapsedTime <= _roofFallingTime)
                {
                    Vector3 roofPos = roofGameObject.transform.position;
                    roofPos.y = _roofInitialPosY +
                        (_roofFinalPosY - _roofInitialPosY) * Mathf.Pow((_elapsedTime / _roofFallingTime), 2);
                    roofGameObject.transform.position = roofPos;

                    _elapsedTime += Time.deltaTime;
                }
                else
                {
                    float roofPosXAbs = Mathf.Abs(roofGameObject.transform.position.x);

                    if (roofPosXAbs <= 0.3f)
                    {
                        _roofResult = 2;
                        _guideText.text = "ÈÇ¸¢ÇØ!";
                    }
                    else if (roofPosXAbs <= 1f)
                    {
                        _roofResult = 1;
                        _guideText.text = "ÁÁ¾Æ!";
                    }
                    else
                    {
                        _roofResult = 0;
                        _guideText.text = "ÀÌ·±!";
                        _piggyBehaviour.SetImage(1);
                    }

                    _elapsedTime = 0f;
                    _roofState = 2;
                }
                break;
            case 2:
                if (_elapsedTime >= 2f)
                {
                    _timeBarControl.EndTimer();
                    GetComponentInParent<GameControl>().Timeout();
                }
                _elapsedTime += Time.deltaTime;
                break;
        }
    }
}
