using System;
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

    public bool hasWon;
    public GameObject successBG;
    public GameObject failedBG;
    public GameObject lifeText;

    // Update is called once per frame
    void Update()
    {
        timePassed = Mathf.Clamp(timePassed + Time.deltaTime, 0, 30000);
        if (timePassed < waitTime + fadeInTime)
        {
            this.GetComponent<Image>().color = new Color(55.0f / 255, 55.0f / 255, 65.0f / 255, Mathf.Clamp(timePassed - waitTime, 0, fadeInTime) / fadeInTime);
        }
        else if (timePassed <= waitTime + fadeInTime + delayTime)
        {
            lifeText.GetComponent<TextUpdater>().UpdateText();
            if (hasWon)
            {
                successBG.SetActive(true);
            }
            else
            {
                failedBG.SetActive(true);
            }
        }
        else if (timePassed <= waitTime + fadeInTime + delayTime + fadeOutTime)
        {
            this.GetComponent<Image>().color = new Color(55.0f / 255, 55.0f / 255, 65.0f / 255, Mathf.Clamp(waitTime + fadeInTime + delayTime + fadeOutTime - timePassed, 0, fadeOutTime) / fadeOutTime);
            
            if (hasWon)
            {
                successBG.SetActive(false);
            }
            else
            {
                failedBG.SetActive(false);
            }
          }
    }

    public void startCover(bool hasWon)
    {
        this.hasWon = hasWon;
        timePassed = 0;
    }
}
