namespace DelegatesAndEvents
{
    public delegate void LogHandler(string message);

    public class Logger
    {
        public void LogToConsole(string message)
        {
            Console.WriteLine("Console Log: " + message);
        }

        public void LogToFile(string message)
        {
            Console.WriteLine("File log: " + message);
        }
    }

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
        }

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
