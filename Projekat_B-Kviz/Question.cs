using System.Collections.Generic;

public class Question
{
    public string Text { get; set; } // Tekst pitanja
    public List<string> Answers { get; set; } // Lista ponuđenih odgovora
    public string CorrectAnswer { get; set; } // Tačan odgovor

    public Question(string text, List<string> answers, string correctAnswer)
    {
        Text = text;
        Answers = answers;
        CorrectAnswer = correctAnswer;
    }
}