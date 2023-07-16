using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Events;

public class GameCommonData : MonoBehaviour
{
    public string gameName;
    public float timeLimit;
    public List<GameObject> itemInfo;
    public UnityEvent initFunc;
    public UnityEvent timeoverFunc;

    public int returnValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Timeover()
    {
        timeoverFunc.Invoke();
        if (GetComponentInParent<GameControl>() != null)
        {
            GetComponentInParent<GameControl>().EndGameWith(returnValue);
        }
    }
}