namespace DelegatesAndEvents
{
 
    // 1. Declaration
    public delegate void Notify(string message);
    internal class Program
    {
        static void Main(string[] args)
        {

            // 2. Instantiation
            Notify notifyDelegate = ShowMessage;
            //Notify notifyDelegate = new Notify(ShowMessage);

            // 3. Invocation
            notifyDelegate("Hello, Delegates!");

            Logger logger = new Logger();
            LogHandler logHandler = logger.LogToConsole;
            logHandler += logger.LogToFile; // Multicast delegate
            
            logHandler("Logging to file.");

            foreach (LogHandler handler in logHandler.GetInvocationList())
            {
                try
                {
                    handler("This is a log message.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error invoking handler: {ex.Message}");
                }
            }

            logHandler -= logger.LogToFile; // Remove one handler
            Logger.InvokeSafely(logHandler, "This is a safe log message.");

            int[] intArray = { 1, 2, 3, 4, 5 };
            string[] stringArray = { "One", "Two", "Three" };
            PrintItemArray(intArray);
            PrintItemArray(stringArray);

            Person[] people = {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Denis", Age = 36 },
                new Person { Name = "Charlie", Age = 35 }
            };

            PersonSorter.Sort(people, CompareByAge);

            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}");
            }

            PersonSorter.Sort(people, CompareByName);

            Console.WriteLine("Sorted by Name:");
            foreach (Person person in people)
            {
                Console.WriteLine($"{person.Name}, Age: {person.Age}");
            }
        }

        // Method that matches the delegate signature
        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }

        // Generic method to print items of any type
        public static void PrintItemArray<T>(T[] items)
        {
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static int CompareByAge(Person x, Person y)
        {
            return x.Age.CompareTo(y.Age);
        }

        static int CompareByName(Person x, Person y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
