namespace QuizApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Question[] questions = new Question[]
            {
                new Question("What is the capital of Germany?",
                new string[]
                {
                    "Paris", "Berlin", "London", "Madrid"
                }, 1)
            };

            Quiz myQuiz = new Quiz(questions);
            myQuiz.DisplayQuestion(questions[0]);
            myQuiz.DisplayAnswers(questions[0]);

            int userChoice = int.Parse(Console.ReadLine()) - 1;
            bool correct = questions[0].IsCorrectAnswer(userChoice);
            Console.WriteLine(correct);
        }
    }
}
