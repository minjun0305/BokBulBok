using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField] private FillingRates fillingRates;

    private RectTransform _rectTransform;
    
    private float _fillingRatePerClick;
    private float _maxWaterHeight;
    public float FillingRate { get; private set; }

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _maxWaterHeight = _rectTransform.rect.height;

        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0f);

        _fillingRatePerClick = GetComponentInParent<WaterPourControl>().HardMode
            ? fillingRates.rateInHardMode
            : fillingRates.rateInEasyMode;
    }

    private void Update()
    {
        if (FillingRate >= 100)
        {
            GetComponentInParent<WaterPourControl>().Win();
        }

        FillingRate -= 0.05f;
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _maxWaterHeight * FillingRate / 100);
    }

    public void Fill()
    {
        FillingRate += _fillingRatePerClick + Random.Range(-0.3f, 0.1f);
        _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _maxWaterHeight * FillingRate / 100);
    }
}
