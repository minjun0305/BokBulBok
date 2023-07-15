using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class ButtonBehaviour : MonoBehaviour
{
    public int buttonOrder;
    [SerializeField] private AnswerButtonPosition buttonPositionList;
    
    private Image _imageComponent;
    [SerializeField] private Color pressedColor;
    [SerializeField] private Color unpressedColor;
    
    private void Start()
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
        _imageComponent.color = pressedColor;
    }

    public void Unpress()
    {
        _imageComponent.color = unpressedColor;
    }

    public void SetText(string text)
    {
        TMP_Text textComponent = GetComponentInChildren<TMP_Text>();
        textComponent.SetText(text);
    }
}
