using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private int _currentlySelected;
    [SerializeField] private AnswerButtonPosition _buttonPosition;
    [SerializeField] private int _buttonXSize;
    [SerializeField] private int _buttonYSize;

    [SerializeField] private GameObject _buttonPrefab;
    private List<ButtonBehaviour> _buttonComponents;

    private void Start()
    {
        _buttonComponents = new List<ButtonBehaviour>();
        int i = 1;

        foreach (Vector2 buttonPos in _buttonPosition.PositionList)
        {
            GameObject generatedButton = Instantiate(_buttonPrefab, buttonPos, Quaternion.identity, transform);
            generatedButton.GetComponent<ButtonBehaviour>().buttonOrder = i;
            i++;
            _buttonComponents.Add(generatedButton.GetComponent<ButtonBehaviour>());
        }

        StartCoroutine("InitializeButtonText");
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
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
        int buttonXOffset = _buttonXSize / 2;
        int buttonYOffset = _buttonYSize / 2;

        for (int i = 1; i <= _buttonPosition.PositionList.Length; i++)
        {
            float buttonXPos = _buttonPosition.PositionList[i - 1].x;
            float buttonYPos = _buttonPosition.PositionList[i - 1].y;
            if (pos.x <= buttonXPos + buttonXOffset && pos.x >= buttonXPos - buttonXOffset &&
                pos.y <= buttonYPos + buttonYOffset && pos.y >= buttonYPos - buttonYOffset)
            {
                return i;
            }
        }

        return 0;
    }
    
    public IEnumerator InitializeButtonText()
    {
        yield return new WaitForEndOfFrame();

        QuestionSet question = GetComponentInParent<SpinxQuizControl>().GetCurrentQuestion();
        foreach (ButtonBehaviour button in _buttonComponents)
        {
            string text = button.buttonOrder switch
            {
                1 => question.Answer1,
                2 => question.Answer2,
                3 => question.Answer3,
                _ => ""
            };
        }
    }
}
