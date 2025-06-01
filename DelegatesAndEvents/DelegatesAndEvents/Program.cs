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
            logHandler("Logging to console.");

            logHandler = logger.LogToFile;
            logHandler("Logging to file.");

            int[] intArray = { 1, 2, 3, 4, 5 };
            string[] stringArray = { "One", "Two", "Three" };
            PrintItemArray(intArray);
            PrintItemArray(stringArray);

            Person[] people = {
                new Person { Name = "Alice", Age = 30 },
                new Person { Name = "Bob", Age = 25 },
                new Person { Name = "Charlie", Age = 35 }
            };
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
    }
}
