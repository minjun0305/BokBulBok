using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverFader : MonoBehaviour
{
    public float waitTime;
    public float fadeInTime;
    public float delayTime;
    public float fadeOutTime;

    public float timePassed;

    // Update is called once per frame
    void Update()
    {
        timePassed = Mathf.Clamp(timePassed + Time.deltaTime, 0, 30000);
        if (timePassed < waitTime + fadeInTime)
        {
            this.GetComponent<Image>().color = new Color(55.0f/255, 55.0f/255, 65.0f/255, Mathf.Clamp(timePassed - waitTime, 0, fadeInTime) / fadeInTime);
        }
        else if (timePassed <= waitTime + fadeInTime + delayTime + fadeOutTime)
        {
            this.GetComponent<Image>().color = new Color(55.0f/255, 55.0f/255, 65.0f/255, Mathf.Clamp(waitTime +fadeInTime + delayTime+ fadeOutTime - timePassed, 0, fadeOutTime) / fadeOutTime);
        }
    }

    public void startCover()
    {
        timePassed = 0;
    }
}
