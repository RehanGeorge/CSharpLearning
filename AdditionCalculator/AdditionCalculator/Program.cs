namespace AdditionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Enter the First Number");
            double number1 = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second Number");
            double number2 = Double.Parse(Console.ReadLine());

            double number3 = number1 + number2;
            Console.WriteLine("The sum is: " + number3);

            //Alternate way of writing it
            Console.WriteLine($"The sum is {number3}");
        }
    }
}
