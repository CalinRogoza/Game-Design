[System.Serializable]
public class Question
{
    public string question;
    public int correctAnswer;
    public string option1;
    public string option2;
    public string option3;
    public string option4;
    public readonly int points;

    public Question(string question, int correctAnswer, string option1, string option2, string option3, string option4, int points)
    {
        this.question = question;
        this.correctAnswer = correctAnswer;
        this.option1 = option1;
        this.option2 = option2;
        this.option3 = option3;
        this.option4 = option4;
        this.points = points;
    }
}
