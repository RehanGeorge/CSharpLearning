namespace Interfaces
{
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class CreditCardProcessor: IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing credit card payment of " + amount);
            // Implement credit card payment logic here
        }
    }

    public class PaypalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine("Processing PayPal payment of " + amount);
            // Implement PayPal payment logic here
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _processor;

        public PaymentService( IPaymentProcessor processor )
        {
            _processor = processor;
        }

        public void ProcessOrderPayment(decimal amount)
        {
            _processor.ProcessPayment(amount);
        }
    }

    public interface IAnimal
    {
        void MakeSound();
        void Eat(string food);
    }

    public class Dog : IAnimal
    {
        public void Eat(string food)
        {
            Console.WriteLine("Dog ate " + food);
        }

        public void MakeSound()
        {
            Console.WriteLine("Dog barks");
        }
    }

    public class Cat: IAnimal
    {
        public void Eat(string food)
        {
            Console.WriteLine("Cat ate " + food);
        }
        public void MakeSound()
        {
            Console.WriteLine("Cat meows");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.MakeSound();
            dog.Eat("bone");

            Cat cat = new Cat();
            cat.MakeSound();
            cat.Eat("fish");
        }
    }
}
