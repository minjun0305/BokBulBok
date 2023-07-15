using TMPro;
using UnityEngine;

class QuestionBox : MonoBehaviour
{
    private TMP_Text _textBox;

    private void Awake()
    {
        _textBox = GetComponentInChildren<TMP_Text>();
    }

    public void SetQuestionText(string text)
    {
        _textBox.SetText(text);
    }
}