using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private int _currentlySelected;
    [SerializeField] private AnswerButtonPosition buttonPosition;
    [SerializeField] private int buttonXSize;
    [SerializeField] private int buttonYSize;

    [SerializeField] private GameObject buttonPrefab;
    private List<ButtonBehaviour> _buttonComponents;

    private void Awake()
    {
        _buttonComponents = new List<ButtonBehaviour>();
        int i = 1;

        foreach (Vector2 buttonPos in buttonPosition.PositionList)
        {
            GameObject generatedButton = Instantiate(buttonPrefab, buttonPos, Quaternion.identity, transform);
            generatedButton.GetComponent<ButtonBehaviour>().buttonOrder = i;
            i++;
            _buttonComponents.Add(generatedButton.GetComponent<ButtonBehaviour>());
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int clickedButton = GetButtonByPosition(mousePos);
            if (clickedButton == 0) return;

            for (int i = 1; i <= _buttonComponents.Count; i++)
            {
                if (i == clickedButton) _buttonComponents[i - 1].Press();
                else                    _buttonComponents[i - 1].Unpress();
            }
        }
    }

    private int GetButtonByPosition(Vector2 pos)
    {
        float buttonXOffset = (float) buttonXSize / 2;
        float buttonYOffset = (float) buttonYSize / 2;

        for (int i = 1; i <= buttonPosition.PositionList.Length; i++)
        {
            float buttonXPos = buttonPosition.PositionList[i - 1].x;
            float buttonYPos = buttonPosition.PositionList[i - 1].y;
            if (pos.x <= buttonXPos + buttonXOffset && pos.x >= buttonXPos - buttonXOffset &&
                pos.y <= buttonYPos + buttonYOffset && pos.y >= buttonYPos - buttonYOffset)
            {
                Debug.Log(i);
                return i;
            }
        }

        Debug.Log("0");
        return 0;
    }

    public void SetText(QuestionSet questionSet)
    {
        foreach (ButtonBehaviour button in _buttonComponents)
        {
            string text = button.buttonOrder switch
            {
                1 => questionSet.Answer1,
                2 => questionSet.Answer2,
                3 => questionSet.Answer3,
                _ => ""
            };
            button.SetText(text);
        }
    }
}
