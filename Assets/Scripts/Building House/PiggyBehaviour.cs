using UnityEngine;
using UnityEngine.UI;

public class PiggyBehaviour : MonoBehaviour
{
    public Sprite[] sprites;

    public void SetImage(int idx)
    {
        GetComponent<Image>().sprite = sprites[idx];
    }
}
