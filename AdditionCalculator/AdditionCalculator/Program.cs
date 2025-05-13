namespace AdditionCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Enter the First Number");
            int number1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Second Number");
            int number2 = Int32.Parse(Console.ReadLine());

            int number3 = number1 + number2;
            Console.WriteLine("The sum is: " + number3);
        }
    }
}
