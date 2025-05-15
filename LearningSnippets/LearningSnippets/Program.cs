namespace LearningSnippets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void ConvertFunction()
            {
                // explicit conversion
                int myInt = 132;

                long myLong = (long)myInt;
                Console.WriteLine(myLong);

                double myDouble = 32.34;
                Console.WriteLine(myDouble);

                int myInt2 = (int)myDouble;
                Console.WriteLine(myInt2);

                string numberString = "123";
                int result = int.Parse(numberString);

                string myBoolString = "true";
                bool myBool = Convert.ToBoolean(myBoolString);
                Console.WriteLine(myBool);

                // implicitly typed variable
                var myFavoriteGenre = "Non-Fiction";

                var number1 = 14;
                var number2 = 23;

                int number3 = number1 + number2;

                Console.WriteLine("The sum is {0}, and the first number is {1} with the second number {2}", number3, number1, number2);
            }

            static void Escaping()
            {
                string s1 = "this is a \"string\" with \na backslash \\ and a colon:";
                Console.WriteLine(s1);
            }

            static void IfFunction()
            {
                int month = 5;
                if (month == 5)
                    Console.WriteLine("Month is May");
            }

            static void SwitchFunction()
            {
                int month = 2;
                string monthName = "blank";

                switch (month)
                {
                    case 1:
                        monthName = "January";
                        break;
                    case 2:
                        monthName = "February";
                        break;
                    default:
                        break;
                }
                Console.WriteLine($"The month name is {monthName}");
            }

            static void QuizApp()
            {
                string[] questions = {"What is the capital of Germany?", "What is 2+2?", "What color do you get by mixing blue and yellow?"};
                string[] answers = { "Berlin", "4", "Green" };

                int score = 0;
                
                for (int i = 0; i < questions.Length; i++)
                {
                    Console.WriteLine(questions[i]);
                    string userAnswer = Console.ReadLine();

                    if (userAnswer.Trim().ToLower() == answers[i].ToLower())
                    {
                        Console.WriteLine("Correct!");
                        score = score + 1;
                    }
                    else
                    {
                        Console.WriteLine("Wrong, the correct answer is: " + answers[i]);
                    }
                }

                Console.WriteLine($"Your final score is {score} / {questions.Length}");
            }

            static void NumberCheck()
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 11);

                Console.WriteLine("What is the number?");
                string userInput = Console.ReadLine();
                int userNumber;

                bool validNumber = int.TryParse(userInput, out userNumber);

                if (validNumber && userNumber == randomNumber)
                {
                    Console.WriteLine("Congratulations, you win!");
                }
                else
                {
                    Console.WriteLine("Wrong number, try again. The correct number was: " + randomNumber);
                }

            }
            
            static void Loops()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(new string('\n', i));
                    Console.WriteLine("rocket");
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                int counter = 0;
                while (counter < 10)
                {
                    Console.WriteLine(counter);
                    counter++;
                }
            }

            static void GuessTheNumber()
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 11);

                Console.WriteLine("Guess the number I am thinking of between 1 and 10:");

                string userChoice = Console.ReadLine();
                bool validNumber = int.TryParse(userChoice, out int numberChoice);

                while (validNumber)
                {
                    if (validNumber && numberChoice == randomNumber)
                    {
                        Console.WriteLine("You win");
                        break;
                    }
                    Console.WriteLine("Guess again");
                    userChoice = Console.ReadLine();
                    validNumber = int.TryParse(userChoice, out numberChoice);
                }
            }

            static void DoWhileLoop()
            {
                int counter = 0;
                do
                {
                    Console.WriteLine(counter);
                    counter++;
                }
                while (counter < 10000);
            }

            static void arrayList()
            {

            }
        }
    }
}
