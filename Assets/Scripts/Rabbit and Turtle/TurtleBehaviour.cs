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
    private GameObject _turtleGameobject;
    private TMP_Text _guideText;
    private Slider _turtleSpeedSlider;
    private RabbitBehaviour _rabbitBehaviour;

    private const float _turtleSpeedValue = 0.15f;
    private const float _turtleSpeedDecreseValue = 0.5f;
    private const float _turtleProgressValue = 0.15f;
    
    private void UpdateTurtle()
    {
        Vector3 turtlePos = _turtlePosInitial;
        turtlePos.x = _turtlePosInitial.x + _turtlePathLen * _turtleProgress;
        _turtleGameobject.transform.position = turtlePos;

        _turtleSpeedSlider.value = _turtleSpeed;
    }

    public void RabbitAndTurtleStart()
    {
        _rabbitAwaken = false;
        _turtleWin = false;
        _turtleProgress = 0f;
        _turtleSpeed = 0f;

        _turtleGameobject = GameObject.Find("Turtle");
        _guideText = GameObject.Find("GuideText").GetComponent<TMP_Text>();
        _turtleSpeedSlider = GameObject.Find("TurtleSpeedGauge").GetComponentInChildren<Slider>();
        _rabbitBehaviour = GameObject.Find("Rabbit").GetComponent<RabbitBehaviour>();

        _turtlePosInitial = _turtleGameobject.transform.position;
        _turtlePathLen = 2 * Mathf.Abs(_turtlePosInitial.x);

        _rabbitBehaviour.SetImage(0);
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
                _guideText.text = "≈‰≥¢∞° ±˙ πˆ∑»¥Ÿ!";
            }
            else if (_turtleSpeed >= 0.7f)
            {
                _turtleProgress += _turtleProgressValue * Time.deltaTime;
                if (_turtleProgress >= 1f)
                {
                    _turtleWin = true;
                    _guideText.text = "¿Ã∞Â¥Ÿ!";
                }
            }

            UpdateTurtle();

            _turtleSpeed = Mathf.Clamp01(_turtleSpeed - _turtleSpeedDecreseValue * Time.deltaTime);
        }
    }
}
