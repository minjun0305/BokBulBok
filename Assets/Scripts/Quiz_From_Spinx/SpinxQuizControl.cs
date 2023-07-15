using System;
using System.Collections.Generic;
using UnityEngine;

public class SpinxQuizControl : MonoBehaviour
{
    private List<QuestionSet> _questionList;
    
    // Start is called before the first frame update
    private void Start()
    {
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

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void EndGameWith(int chosenItem)
    {
        
    }
}
