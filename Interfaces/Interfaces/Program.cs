namespace Interfaces
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
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

            string directoryPath = @"D:\Learning\C#\Logs";
            string filePath = System.IO.Path.Combine(directoryPath, "log.txt");

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(filePath, "Hello World" + "\n");
        }
    }
}
