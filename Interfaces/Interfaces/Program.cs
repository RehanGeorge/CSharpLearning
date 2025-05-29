namespace Interfaces
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger: ILogger
    {
        public void Log(string message)
        {
            string directoryPath = @"D:\Learning\C#\Logs";
            string filePath = System.IO.Path.Combine(directoryPath, "log.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(filePath, message + "\n");
        }
    }

    public class DatabaseLogger: ILogger
    {
        public void Log(string message)
        {
            //Implement database logging logic here
            Console.WriteLine("Logging to database: " + message);
        }
    }

    public class Application
    {
        private readonly ILogger _logger;

        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void DoWork()
        {
            _logger.Log("Work started.");
            // Do some work here
            _logger.Log("Work completed.");
        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            ILogger fileLogger = new FileLogger();
            Application app = new Application(fileLogger);
            app.DoWork();

            ILogger dbLogger = new DatabaseLogger();
            app = new Application(dbLogger);
            app.DoWork();

            /*
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("bone");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("fish");

            IPaymentProcessor creditCardProcessor = new CreditCardProcessor();
            PaymentService paymentService = new PaymentService(creditCardProcessor);
            paymentService.ProcessOrderPayment(100.00m);

            IPaymentProcessor paypalProcessor = new PaypalProcessor();
            paymentService = new PaymentService(paypalProcessor);
            paymentService.ProcessOrderPayment(50.00m);
            */
        }
    }
}
