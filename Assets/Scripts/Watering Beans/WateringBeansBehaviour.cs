using UnityEngine;

public class WateringBeansBehaviour : MonoBehaviour
{
    private bool _mouseButtonDown;
    
    private int _beanState;
    
    private float _currentWatering;
    private float _prevWatering;
    private float _wateringProgress;
    private float _prevMousePosY;

    private BeanBehaviour _beanBehaviour;
    private GuideImageBehaviour _guideImageBehaviour;

    private const float _maxTiltAngle = 50f;

    public GameObject WateringCanGameObject;
    public GameObject WateringGameObject;
    
    public void WateringBeansStart()
    {
        _mouseButtonDown = false;
        _beanState = 0;
        _currentWatering = 0f;
        _prevWatering = 0f;
        _wateringProgress = 0f;
        _beanBehaviour = GetComponentInChildren<BeanBehaviour>();
        _guideImageBehaviour = GetComponentInChildren<GuideImageBehaviour>();
        _guideImageBehaviour.GuideAnimationStart();
        WateringGameObject.SetActive(false);
    }

    public void WateringBeansTimeout()
    {
        _guideImageBehaviour.GuideAnimationStop();
        GetComponentInParent<GameControl>().EndGameWith(_beanState);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _mouseButtonDown = true;
            _prevMousePosY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _mouseButtonDown = false;
            _prevWatering = _currentWatering;
        }

        if (_mouseButtonDown)
        {
            _currentWatering = Mathf.Clamp((Input.mousePosition.y - _prevMousePosY) / 6f - _prevWatering, 0f, _maxTiltAngle);
            WateringCanGameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, _currentWatering);
        }

        if (_currentWatering >= 10f)
        {
            WateringGameObject.SetActive(true);
            _wateringProgress += _currentWatering * Time.deltaTime;

            if (_wateringProgress >= 300f)
            {
                _beanBehaviour.SetImage(2);
                _beanState = 0;
            }
            else if (_wateringProgress >= 100f)
            {
                _beanBehaviour.SetImage(1);
                _beanState = 1;
            }
        }
        else
        {
            WateringGameObject.SetActive(false);
        }
    }
}
