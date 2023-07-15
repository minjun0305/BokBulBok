using TMPro;
using UnityEngine;

public class WateringBeansBehaviour : MonoBehaviour
{
    private bool _isWatering;
    private bool _isBeanDead;

    private float _wateringProgress;
    private float _initialMousePosY;
    private float _initial;

    private TMP_Text _guideText;
    private BeanBehaviour _beanBehaviour;

    private const int _maxTiltAngle = 50;

    public GameObject wateringCanGameObject;
    public GameObject wateringGameObject;
    
    public void WateringBeansStart()
    {
        _wateringProgress = 0f;
        _isWatering = false;
        _isBeanDead = false;
        _guideText = GetComponentInChildren<TMP_Text>();
        _beanBehaviour = GetComponentInChildren<BeanBehaviour>();
        wateringGameObject.SetActive(false);
    }

    public void WateringBeansTimeout()
    {
        GetComponentInParent<GameCommonData>().returnValue = 0; // TODO
    }

    // Update is called once per frame
    void Update()
    {
        if (!_isBeanDead)
        {
            if (!_isWatering && Input.GetMouseButtonDown(0))
            {
                _initialMousePosY = Input.mousePosition.y;
                _isWatering = true;
                wateringGameObject.SetActive(true);
            }
            else if (_isWatering)
            {
                float currentWatering = Mathf.Clamp(Input.mousePosition.y - _initialMousePosY, 0f, _maxTiltAngle);

                _wateringProgress += currentWatering * Time.deltaTime;

                wateringCanGameObject.GetComponent<RectTransform>().eulerAngles = new Vector3(0f, 0f, currentWatering);

                if (Input.GetMouseButtonUp(0))
                {
                    _isWatering = false;
                    wateringGameObject.SetActive(false);
                }
            }
        }
    }
}
