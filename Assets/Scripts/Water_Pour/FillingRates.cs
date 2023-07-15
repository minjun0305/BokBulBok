using UnityEngine;

[CreateAssetMenu(fileName="FillingRatesContainer", menuName="Containers/FillingRates", order=1)]
public class FillingRates : ScriptableObject
{
    public float rateInEasyMode;
    public float rateInHardMode;
}