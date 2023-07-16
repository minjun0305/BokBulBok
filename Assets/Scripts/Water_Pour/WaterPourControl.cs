using System.Collections;
using UnityEngine;

public class WaterPourControl : MonoBehaviour
{
    public bool HardMode { get; private set; }

    private GameObject gameControl;

    private void Awake()
    {
        HardMode = Random.Range(0.0f, 1.0f) > 0.75f;
    }

    private void Start()
    {
        gameControl = GetComponentInParent<GameCommonData>().GetComponentInParent<GameControl>().gameObject;
    }

    public void Win()
    {
        StopCoroutine("SetTimeOut");
        gameControl.GetComponent<GameControl>().EndGameWith(1);
    }

    public void Lose()
    {
        gameControl.GetComponent<GameControl>().EndGameWith(0);
    }
}
