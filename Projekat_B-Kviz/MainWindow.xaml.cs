using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Animation;

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
        private readonly SolidColorBrush defaultAnswerColor;
        private readonly SolidColorBrush correctAnswerColor;
        private readonly SolidColorBrush wrongAnswerColor;

        public MainWindow()
        {
            InitializeComponent();

            defaultAnswerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2196F3"));
            correctAnswerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4CAF50"));
            wrongAnswerColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F44336"));

            ResetGameState();
        }

        private int LoadNumberOfQuestions()
        {
            if (LevelSelector.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedLevel = selectedItem.Content.ToString();
                LevelSelector.IsEnabled = false;
                return selectedLevel.Contains("Hard") ? 20 : 10;
            }
            else
            {
                MessageBox.Show("Please select a difficulty level", "Select Difficulty", MessageBoxButton.OK, MessageBoxImage.Information);
                return 0;
            }
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

                allQuestions = allQuestions.OrderBy(q => System.Guid.NewGuid()).ToList();

                questions = allQuestions.Take(numOfQuestions).ToList();

                if (questions.Count < numOfQuestions)
                {
                    MessageBox.Show($"Warning: Only {questions.Count} questions available.",
                        "Not Enough Questions", MessageBoxButton.OK, MessageBoxImage.Warning);
                    numOfQuestions = questions.Count;
                    leftQuestions = numOfQuestions;
                }
            }
            else
            {
                MessageBox.Show("Questions file not found! Please check the file path.",
                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                ResetGameState();
            }
        }

        private void ShowQuestion()
        {
            if (currentQuestionIndex < questions?.Count)
            {
                var question = questions[currentQuestionIndex];
                QuestionText.Text = question.Text;

                Answer1.Background = defaultAnswerColor;
                Answer2.Background = defaultAnswerColor;
                Answer3.Background = defaultAnswerColor;

                List<string> shuffledAnswers = question.Answers.OrderBy(a => System.Guid.NewGuid()).ToList();

                Answer1.Content = shuffledAnswers[0];
                Answer2.Content = shuffledAnswers[1];
                Answer3.Content = shuffledAnswers[2];

                Answer1.IsEnabled = true;
                Answer2.IsEnabled = true;
                Answer3.IsEnabled = true;
            }
            else if (questions != null && questions.Count > 0)
            {
                ShowResults();
            }
        }

        private void ShowResults()
        {
            double percentage = (double)correctAnswers / numOfQuestions * 100;

            string resultMessage = $"Quiz Complete!\n\nScore: {score}\nCorrect Answers: {correctAnswers}/{numOfQuestions}\nAccuracy: {percentage:F1}%";

            if (percentage >= 90)
                resultMessage += "\n\nExcellent! You're a quiz master!";
            else if (percentage >= 70)
                resultMessage += "\n\nGreat job! You know a lot!";
            else if (percentage >= 50)
                resultMessage += "\n\nGood effort! Keep learning!";
            else
                resultMessage += "\n\nKeep practicing! You'll improve!";

            MessageBox.Show(resultMessage, "Quiz Results", MessageBoxButton.OK, MessageBoxImage.Information);

            ResetGameState();
        }

        private void StartQuiz_Click(object sender, RoutedEventArgs e)
        {
            numOfQuestions = LoadNumberOfQuestions();

            if (numOfQuestions == 0)
                return;

            leftQuestions = numOfQuestions;
            currentQuestionIndex = 0;
            score = 0;
            correctAnswers = 0;

            ScoreText.Text = "0";
            CorrectNum.Text = "0";
            LeftQuestionsNum.Text = leftQuestions.ToString();

            LoadQuestions();

            if (questions != null && questions.Count > 0)
            {
                StartQuizButton.IsEnabled = false;
                ShowQuestion();
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton && questions != null && currentQuestionIndex < questions.Count)
            {
                string chosenAnswer = clickedButton.Content.ToString();
                string correctAnswer = questions[currentQuestionIndex].CorrectAnswer;

                Answer1.IsEnabled = false;
                Answer2.IsEnabled = false;
                Answer3.IsEnabled = false;

                if (chosenAnswer == correctAnswer)
                {
                    score += 10;
                    correctAnswers++;
                    CorrectNum.Text = correctAnswers.ToString();
                    clickedButton.Background = correctAnswerColor;

                    AnimateScore();
                }
                else
                {
                    clickedButton.Background = wrongAnswerColor;

                    if (Answer1.Content.ToString() == correctAnswer)
                        Answer1.Background = correctAnswerColor;
                    else if (Answer2.Content.ToString() == correctAnswer)
                        Answer2.Background = correctAnswerColor;
                    else if (Answer3.Content.ToString() == correctAnswer)
                        Answer3.Background = correctAnswerColor;
                }

                ScoreText.Text = score.ToString();
                currentQuestionIndex++;
                leftQuestions--;
                LeftQuestionsNum.Text = leftQuestions.ToString();

                System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
                timer.Interval = new System.TimeSpan(0, 0, 1); 
                timer.Tick += (s, args) => {
                    timer.Stop();
                    ShowQuestion();
                };
                timer.Start();
            }
        }

        private void AnimateScore()
        {
            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            ScoreText.RenderTransform = scale;

            DoubleAnimation growAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 1.5,
                Duration = new Duration(System.TimeSpan.FromMilliseconds(200)),
                AutoReverse = true
            };

            scale.BeginAnimation(ScaleTransform.ScaleXProperty, growAnimation);
            scale.BeginAnimation(ScaleTransform.ScaleYProperty, growAnimation);
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to end the game? This will close the application.",
                "End Game",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void RestartGame_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Are you sure you want to restart the game? You will lose your current progress.",
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
            LevelSelector.SelectedIndex = -1;
            QuestionText.Text = "Select a difficulty level and press Start Quiz";
            Answer1.Content = "Answer 1";
            Answer2.Content = "Answer 2";
            Answer3.Content = "Answer 3";
            ScoreText.Text = "0";
            CorrectNum.Text = "0";
            LeftQuestionsNum.Text = "0";
            StartQuizButton.IsEnabled = true;
            currentQuestionIndex = 0;
            score = 0;
            correctAnswers = 0;
            numOfQuestions = 0;
            leftQuestions = 0;
            questions = null;

            Answer1.Background = defaultAnswerColor;
            Answer2.Background = defaultAnswerColor;
            Answer3.Background = defaultAnswerColor;

            Answer1.IsEnabled = false;
            Answer2.IsEnabled = false;
            Answer3.IsEnabled = false;
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            string helpText =
                "Quiz Game Help\n\n" +
                "1. Select a difficulty level from the dropdown menu\n" +
                "2. Click 'START QUIZ' to begin\n" +
                "3. Read each question carefully\n" +
                "4. Click on one of the answer options\n" +
                "5. Your score will update automatically\n\n" +
                "Scoring:\n" +
                "- Each correct answer earns 10 points\n" +
                "- The scoreboard shows your current score, correct answers, and remaining questions\n\n" +
                "Controls:\n" +
                "- 'END GAME' closes the application\n" +
                "- 'RESTART GAME' resets the quiz and lets you start over\n" +
                "- 'HELP' shows this help message";

            MessageBox.Show(helpText, "Help", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}