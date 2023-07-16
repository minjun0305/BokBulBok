using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurtleBehaviour : MonoBehaviour
{
    private bool _rabbitAwaken;
    private bool _turtleWin;
    
    private float _turtleProgress;
    private float _turtleSpeed;
    private float _turtlePathLen;

    private Vector3 _turtlePosInitial;
    private TMP_Text _guideText;
    private Slider _turtleSpeedSlider;
    private RabbitBehaviour _rabbitBehaviour;

    private const float _turtleSpeedValue = 0.15f;
    private const float _turtleSpeedDecreseValue = 0.5f;
    private const float _turtleProgressValue = 0.15f;

    public GameObject guideTextGameObject;
    public GameObject turtleSpeedGaugeGameObject;
    public GameObject rabbitGameObject;
    public GameObject spaceKeyGuideGameObject;

    private void UpdateTurtle()
    {
        Vector3 turtlePos = _turtlePosInitial;
        turtlePos.x = _turtlePosInitial.x + _turtlePathLen * _turtleProgress;
        transform.position = turtlePos;

        _turtleSpeedSlider.value = _turtleSpeed;
    }

    public void RabbitAndTurtleStart()
    {
        _rabbitAwaken = false;
        _turtleWin = false;
        _turtleProgress = 0f;
        _turtleSpeed = 0f;

        _guideText = guideTextGameObject.GetComponent<TMP_Text>();
        _turtleSpeedSlider = turtleSpeedGaugeGameObject.GetComponentInChildren<Slider>();
        _rabbitBehaviour = rabbitGameObject.GetComponent<RabbitBehaviour>();

        _turtlePosInitial = transform.position;
        _turtlePathLen = 2 * Mathf.Abs(_turtlePosInitial.x);

        _rabbitBehaviour.SetImage(0);
        spaceKeyGuideGameObject.GetComponent<GuideImageBehaviour>().GuideAnimationStart();
    }

    public void RabbitAndTurtleTimeover()
    {
        GetComponentInParent<GameCommonData>().returnValue = (!_rabbitAwaken && _turtleWin) ? 1 : 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rabbitAwaken && !_turtleWin)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _turtleSpeed += _turtleSpeedValue;
            }

            if (_turtleSpeed >= 0.92f)
            {
                _rabbitAwaken = true;
                _rabbitBehaviour.SetImage(1);
                _guideText.text = "Åä³¢°¡ ±ú ¹ö·È´Ù!";
                spaceKeyGuideGameObject.GetComponent<GuideImageBehaviour>().GuideAnimationStop();
            }
            else if (_turtleSpeed >= 0.7f)
            {
                _turtleProgress += _turtleProgressValue * Time.deltaTime;
                if (_turtleProgress >= 1f)
                {
                    _turtleWin = true;
                    _guideText.text = "ÀÌ°å´Ù!";
                    spaceKeyGuideGameObject.GetComponent<GuideImageBehaviour>().GuideAnimationStop();
                }
            }

            UpdateTurtle();

            _turtleSpeed = Mathf.Clamp01(_turtleSpeed - _turtleSpeedDecreseValue * Time.deltaTime);
        }
    }
}
