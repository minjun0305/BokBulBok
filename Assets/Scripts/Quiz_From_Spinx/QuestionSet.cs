public class QuestionSet
{
    public string Question { get; }
    public string Answer1 { get; }
    public string Answer2 { get; }
    public string Answer3 { get; }
    public int Correct { get; }

    public QuestionSet(string question, string answer1, string answer2, string answer3, int correct)
    {
        Question = question;
        Answer1 = answer1;
        Answer2 = answer2;
        Answer3 = answer3;
        Correct = correct;
    }
}