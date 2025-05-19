using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    internal class Quiz
    {
        private Question[] questions;

        public Quiz(Question[] questions)
        {
            this.questions = questions;
        }

        public void DisplayQuestion(Question question)
        {
            Console.WriteLine(question.QuestionText);
        }

        public void DisplayAnswers(Question question)
        {
            int i = 0;
            foreach (string answer in question.Answers)
            {
                Console.WriteLine($"{++i}. {answer}");
            }
        }
    }
}
