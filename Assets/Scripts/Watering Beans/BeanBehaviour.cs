using UnityEngine;
using UnityEngine.UI;

public class BeanBehaviour : MonoBehaviour
{
    public Sprite[] sprites;

    public void setImage(int idx)
    {
        GetComponent<Image>().sprite = sprites[idx];
    }
}
