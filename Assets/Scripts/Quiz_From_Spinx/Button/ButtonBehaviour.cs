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
