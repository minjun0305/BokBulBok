using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class IkarosDiveRing : MonoBehaviour
{
    public int index;
    public GameObject Ikaros;
    public Vector3 fakePosition
        ;
    private RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        rect = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        IkarosDivePlayer player = this.GetComponentInParent<IkarosDivePlayer>();
        RectTransform rectPlayer = player.GetComponent<RectTransform>();
        float scaleFactor = (3000 + fakePosition.z) / (3000 + player.fakeZ);
        rect.anchoredPosition = new Vector2((fakePosition.x - rectPlayer.anchoredPosition.x) * scaleFactor, (fakePosition.y - rectPlayer.anchoredPosition.y) * scaleFactor);
        scaleFactor *= scaleFactor;
        rect.localScale = new Vector3(scaleFactor, scaleFactor, 1.0f);

        if (player.fakeZ < fakePosition.z)
        {
            float deltaX = fakePosition.x - rectPlayer.anchoredPosition.x - 200;
            float deltaY = fakePosition.y - rectPlayer.anchoredPosition.y - 200;

            if (deltaX * deltaX + deltaY * deltaY > 300 * 300)
            {
                if (index > 3)
                {
                    this.transform.parent.parent.GetComponentInParent<GameControl>().EndGameWith(0);
                }
            }
            else
            {
                if (index <= 3)
                {
                    this.transform.parent.parent.GetComponentInParent<GameControl>().EndGameWith(index);
                }
            }
            this.gameObject.SetActive(false);
        }
        else if (player.fakeZ - fakePosition.z < 100)
        {
            GetComponent<Image>().color = Color.red;
        }
        else if (player.fakeZ - fakePosition.z < 500)
        {
            GetComponent<Image>().color = Color.yellow;
        }
        else if (player.fakeZ - fakePosition.z < 2000)
        {
            GetComponent<Image>().color = Color.grey;
        }
        else
        {
            GetComponent<Image>().color = Color.white;
        }
    }

    public void InitPosition()
    {
        if (index <= 3)
        {
            float degree = (this.GetComponentInParent<IkarosDivePlayer>().randomSeed + (index) * 90) * Mathf.Deg2Rad;
            fakePosition = new Vector3(500 * Mathf.Cos(degree) + 1080, 500 * Mathf.Sin(degree) + 900, 0);
        }
        else
        {
            fakePosition = new Vector3(Random.Range(600,1560),Random.Range(600, 1200), 900 * (index - 3));
        }
    }
}
