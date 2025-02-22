using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace Projekat_B_Kviz
{
    public partial class MainWindow : Window
    {
        private List<Question> questions;
        private int currentQuestionIndex = 0;
        private int score = 0;
        private int correctAnswers = 0;
        private int numOfQuestions = 0;
        private int leftQuestions = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private int loadNumberOfQuestions()
        {
            if (LevelSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedLevel = selectedItem.Content.ToString();
                LevelSelector.IsEnabled = false;
                return selectedLevel.Contains("Hard") ? 20 : 10;
            }
            else return 10;
        }
        private void LoadQuestions()
        {
           
            string filePath = "C:\\Users\\PC\\Desktop\\4 GODINA\\HCI\\Projekti\\Projekat_B-Kviz\\questions.txt";
            List<Question> allQuestions = new List<Question>();

            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines)
                {
                   
                    var parts = line.Split(',');

                    if (parts.Length == 5)
                    {
                        string questionText = parts[0].Trim();
                        List<string> answers = new List<string>
                {
                    parts[1].Trim(),
                    parts[2].Trim(),
                    parts[3].Trim()
                };
                        string correctAnswer = parts[4].Trim();

                        var question = new Question(questionText, answers, correctAnswer);
                        allQuestions.Add(question);
                    }
                }
                questions = allQuestions.Take(numOfQuestions).ToList();
            }
            else
            {
                MessageBox.Show("Questions file not found!");
            }
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions.Count)
            {
                var question = questions[currentQuestionIndex];
                QuestionText.Text = question.Text;

                Answer1.Content = question.Answers[0];
                Answer2.Content = question.Answers[1];
                Answer3.Content = question.Answers[2];
            }
            else
            {
                MessageBox.Show("Kviz je završen! Tvoj rezultat: " + score);
                ResetGameState();
            }
        }
        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            numOfQuestions = loadNumberOfQuestions();
            leftQuestions = numOfQuestions;
            LoadQuestions();
            ShowQuestion();
            currentQuestionIndex = 0;
            score = 0;
            CorrectNum.Text = "0";
            ScoreText.Text = "0";
            CorrectNum.Text = "0";
            LeftQuestionsNum.Text = leftQuestions.ToString();
            StartQuizButton.IsEnabled = false;
            ShowQuestion();
        }
        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to end game? That is how you shut down application.",
                                              "End game",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to restart the game? You will lose your current score.",
                                              "Restart Game",
                                              MessageBoxButton.YesNo,
                                              MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                ResetGameState();

            }
        }
        private void ResetGameState()
        {
            LevelSelector.IsEnabled = true;
            QuestionText.Text = "Question will appear here";
            Answer1.Content = "Answer 1";
            Answer2.Content = "Answer 2";
            Answer3.Content = "Answer 3";
            ScoreText.Text = "0";
            CorrectNum.Text = "0";
            LeftQuestionsNum.Text = "0";
            StartQuizButton.IsEnabled = true;
            currentQuestionIndex = 0;
        }
        private void Help_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                string chosenAnswer = clickedButton.Content.ToString();
                string correctAnswer = questions[currentQuestionIndex].CorrectAnswer;

                if (chosenAnswer == correctAnswer)
                {
                    score += 10;
                    correctAnswers++;
                    CorrectNum.Text = correctAnswers.ToString();
                }

                ScoreText.Text = score.ToString();
                currentQuestionIndex++;
                leftQuestions--;
                LeftQuestionsNum.Text = leftQuestions.ToString();
                ShowQuestion();
            }
        }
    }
}