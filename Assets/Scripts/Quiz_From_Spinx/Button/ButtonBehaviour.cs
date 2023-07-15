using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class ButtonBehaviour : MonoBehaviour
{
    public int buttonOrder;
    [SerializeField] private AnswerButtonPosition buttonPositionList;
    
    private Image _imageComponent;
    [SerializeField] private Color pressedColor;
    [SerializeField] private Color unpressedColor;
    
    void Start()
    {
        _imageComponent = GetComponent<Image>();
    }

    public void UpdatePositionWithOrder()
    {
        Vector2 newPos = buttonOrder switch
        {
            1 => buttonPositionList.PositionList[0],
            2 => buttonPositionList.PositionList[1],
            3 => buttonPositionList.PositionList[2],
            _ => Vector2.zero
        };

        transform.position = newPos;
    }

    public void Press()
    {
        _imageComponent.tintColor = pressedColor;
    }

    public void Unpress()
    {
        _imageComponent.tintColor = unpressedColor;
    }

    public void SetText(string text)
    {
        Text textComponent = GetComponentInChildren<Text>();
        textComponent.text = text;
    }
}
