namespace ClassesAdditional
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int result = 0;

            try
            {
                Console.WriteLine("Please enter a number");
                int num1 = int.Parse(Console.ReadLine());
                int num2 = 0;

                result = num1 / num2;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
