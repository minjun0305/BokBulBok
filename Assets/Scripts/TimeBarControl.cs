using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeBarControl : MonoBehaviour
{
    public GameObject GameArea;
    public GameObject filler;
    public bool timePassing = true;
    public float timeLimit = 1.0f;
    public float timeLeft = 0.0f;

    private float barLength;

    // Start is called before the first frame update
    void Start()
    {
        if (filler == null)
        {
            filler = GetComponentInChildren<GameObject>();
        }
        barLength = this.GetComponent<RectTransform>().rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        bool isPos = timeLeft > 0.0f;
        if (timeLeft <= -5.0f)
            return;
        if (timePassing) timeLeft = timeLeft - Time.deltaTime;
        filler.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barLength * Mathf.Clamp(timeLeft/timeLimit, 0.0f, 100.0f));
        if (timeLeft <= 0.0f)
        {
            if (isPos)
            {
                GameArea.GetComponent<GameControl>().Timeout();
            }
            if (timeLeft <= -5.0f)
            {
                GameArea.GetComponent<GameControl>().StartNewGame();
            }
        }
        else if (timeLeft < 5.0f)
        {
            filler.GetComponent<Image>().color = Color.red;
        }
        else if (timeLeft < 10.0f)
        {
            filler.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            filler.GetComponent<Image>().color = Color.green;
        }
    }

    public void SetTimer(float timeLimit)
    {
        this.timeLimit = timeLimit;
        this.timeLeft = timeLimit;
        timePassing = true;
        filler.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, barLength * timeLeft / timeLimit);

    }

    public void EndTimer()
    {
        this.timeLeft = 0f;
        timePassing = true;
    }

    public void PauseTimer()
    {
        timePassing = false;
    }
}
