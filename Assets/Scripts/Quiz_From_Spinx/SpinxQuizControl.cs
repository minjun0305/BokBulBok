using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinxQuizControl : MonoBehaviour
{
    private QuestionBox _questionBox;
    private ButtonController _buttonController;
    private List<QuestionSet> _questionList;
    private int _questionNumber;
    private int _questions;
    private GameCommonData _gameData;
    
    private void Start()
    {
        _gameData = GetComponent<GameCommonData>();
        _questionBox = GetComponentInChildren<QuestionBox>();
        _buttonController = GetComponentInChildren<ButtonController>();
        _questionList = new List<QuestionSet>();
        _questions = 0;
        
        string[] questionText = Resources.Load<TextAsset>("SpinxQuiz/QuestionList").text.Split("\n");
        foreach (string line in questionText)
        {
            if (line.StartsWith("#")) continue;
            
            string[] questionArgs = line.Split("|");
            if (questionArgs.Length != 5) continue;

            try
            {
                string question = questionArgs[0].Trim();
                string answer1 = questionArgs[1].Trim();
                string answer2 = questionArgs[2].Trim();
                string answer3 = questionArgs[3].Trim();
                int correct = int.Parse(questionArgs[4].Trim());
                
                _questionList.Add(new QuestionSet(question, answer1, answer2, answer3, correct));
            }
            catch (FormatException)
            {
                Debug.Log("Format exception occured. Please check the format of content.");
            }
        }
        
        SetNextQuestion();
    }

    public void Evaluate()
    {
        int chosenItem = _buttonController.selected;
        QuestionSet currentQuestion = GetCurrentQuestion();

        if (chosenItem == currentQuestion.Correct)
        {
            _gameData.returnValue = 0;
        }
        else
        {
            _gameData.returnValue = 1;
        }
    }

    public QuestionSet GetCurrentQuestion()
    {
        return _questionList[_questionNumber];
    }
    
    public QuestionSet GetNextQuestion()
    {
        _questionNumber = Random.Range(0, _questionList.Count);
        return _questionList[_questionNumber];
    }

    private void SetNextQuestion()
    {
        QuestionSet nextQuestion = GetNextQuestion();
        _buttonController.SetText(nextQuestion);
        _questionBox.SetQuestionText(nextQuestion.Question);
    }
}
