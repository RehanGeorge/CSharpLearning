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
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
