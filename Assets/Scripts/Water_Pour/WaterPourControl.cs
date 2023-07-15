using System.Collections;
using UnityEngine;

public class WaterPourControl : MonoBehaviour
{
    public bool HardMode { get; private set; }

    [SerializeField] private GameObject gameControl;

    private void Awake()
    {
        HardMode = Random.Range(0.0f, 1.0f) > 0.75f;
    }
    
    private void Start()
    {
        StartCoroutine("SetTimeOut");
    }

    public void Win()
    {
        StopCoroutine("SetTimeOut");
        gameControl.GetComponent<GameControl>().EndGameWith(2);
    }

    private IEnumerator SetTimeOut()
    {
        yield return new WaitForSeconds(30);
        gameControl.GetComponent<GameControl>().EndGameWith(3);
    }
}
