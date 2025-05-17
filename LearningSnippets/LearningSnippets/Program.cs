using System.ComponentModel;
using System.Transactions;

namespace LearningSnippets
{
    internal class Program
    {
        static string myName = "Rehan";
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
                string[] questions = { "What is the capital of Germany?", "What is 2+2?", "What color do you get by mixing blue and yellow?" };
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
                // declare an array
                int[] myIntArray = new int[5];

                myIntArray[0] = 0;
                myIntArray[1] = 1;
                myIntArray[2] = 2;
                myIntArray[3] = 3;
                myIntArray[4] = 4;

                int[] ints = [5, 12, 13, 16, 20];

                foreach (int item in ints)
                {
                    Console.WriteLine(item);
                }
            }

            static void multiDimensions()
            {
                int[,] array2D = new int[3, 3];
                // [0] [0] [0]
                // [0] [0] [0]
                // [0] [0] [0]

                int[,,] array3D = new int[3, 3, 3];

                int[,] array2Dtest = { { 1, 2 }, { 3, 4 } };
                Console.WriteLine(array2Dtest[0, 0]);
                array2Dtest[1, 0] = 5;
                Console.WriteLine(array2Dtest[1, 0]);
            }

            static void WeatherCalculateMethod()
            {
                Console.WriteLine("Enter the number of days to simulate: ");
                int days = int.Parse(Console.ReadLine());

                int[] temperature = new int[days];
                string[] conditions = { "Sunny", "Rainy", "Cloudy", "Snowy" };
                string[] weatherConditions = new string[days];

                Random random = new Random();

                for (int i = 0; i < days; i++)
                {
                    temperature[i] = random.Next(-10, 40);
                    weatherConditions[i] = conditions[random.Next(conditions.Length)];
                }

                int maxTemp = temperature.Max();
                int minTemp = temperature.Min();

                double averageTemp = WeatherCalculatorMethods.CalculateAverageTemp(temperature);
                string mostCommonCondition = WeatherCalculatorMethods.MostCommonCondition(conditions, weatherConditions);

                Console.WriteLine($"The average temperature is {averageTemp} with a max of {maxTemp} and a min of {minTemp}");
                Console.WriteLine($"The most common conditions is {mostCommonCondition}");
            }

            WeatherCalculateMethod();
        }
    }

    internal class Methods
    { 
        void MyFirstMethod()
        {
            Console.WriteLine("MyFirstMethod was called.");
        }

        public static void WriteSomething(string x)
        {
            Console.WriteLine($"You wanted to write: {x}");
        }

        /// <summary>
        /// This takes two integers and returns their sum
        /// </summary>
        /// <param name="x">The first integer to add.</param>
        /// <param name="y">The second integer to add.</param>
        /// <returns>The sum of <paramref name="x"/> and <paramref name="y"/>.</returns>
        public static int Add(int x, int y)
        {
            return x + y;
        }
    }

    internal class WeatherCalculatorMethods
    {
        /// <summary>
        /// Calculates the average temperature basis an input array of temperatures
        /// </summary>
        /// <param name="temperature">The array of temperatures</param>
        /// <returns>The average of the input array</returns>
        internal static double CalculateAverageTemp(int[] temperature)
        {
            double average = 0;
            foreach (int temp in temperature)
            {
                average += temp;
            }
            average = average / temperature.Length;
            return average;
        }

        internal static string MostCommonCondition(string[] conditions, string[] weatherConditions)
        {
            int count = 0;
            string mostCommon = conditions[0];

            for (int i = 0; i < conditions.Length; i++)
            {
                int tempCount = 0;
                for (int j = 0; j < weatherConditions.Length; j++)
                {
                    if (weatherConditions[j] == conditions[i])
                    {
                        tempCount++;
                    }
                }
                if (tempCount > count)
                {
                    count = tempCount;
                    mostCommon = conditions[i];
                }
            }

            return mostCommon;
        }
    }
}

