using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing
            List<string> colors = ["red", "blue", "green", "red"];
            List<int> numbers = new List<int> { 10, 5, 15, 3, 9,  25, 18 };

            Console.WriteLine("Sorting numbers");
            numbers.Sort();

            printItems(numbers);

            Predicate<int> isGreaterThanTen = x => x >= 10;

            Console.WriteLine("Here is the list of numbers greater than 10");
            List<int> higherNumbers = numbers.FindAll(isGreaterThanTen);
            printItems(higherNumbers);

            bool hasLargeNumber = numbers.Any(x => x > 20);
            Console.WriteLine($"There are large numbers in the numbers list: {hasLargeNumber}");

            Console.WriteLine("Printing colors");
            printItems(colors);

            while (colors.Remove("red") == true)
            {
                Console.WriteLine("Deleted 1 red");
            }

            printItems(colors);
        }

        private static void printItems<T>(List<T> items)
        {
            Console.WriteLine("\nCurrent items in the list:");
            foreach (T item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
