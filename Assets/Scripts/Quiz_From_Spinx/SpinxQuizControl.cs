using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpinxQuizControl : MonoBehaviour
{
    private QuestionBox _questionBox;
    private ButtonController _buttonController;
    private List<QuestionSet> _questionList;
    private int _questionNumber;
    
    private void Awake()
    {
        _questionBox = GetComponentInChildren<QuestionBox>();
        _buttonController = GetComponentInChildren<ButtonController>();
        _questionList = new List<QuestionSet>();
        
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
    }

    private void Start()
    {
        SetNextQuestion();
    }

    private void Update()
    {
        
    }

    public void EndGameWith(int chosenItem)
    {
        QuestionSet currentQuestion = GetCurrentQuestion();

        if (chosenItem == currentQuestion.Correct)
        {
            // TODO: do something
        }
        else
        {
            // TODO: do another thing
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
