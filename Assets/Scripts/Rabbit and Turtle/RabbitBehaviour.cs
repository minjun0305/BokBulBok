using UnityEngine;
using UnityEngine.UI;

public class RabbitBehaviour : MonoBehaviour
{
    public Sprite[] rabbitSprites;
    
    public void SetImage(int idx)
    {
        GetComponent<Image>().sprite = rabbitSprites[idx];
    }
}
