using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product> {
                new Product { Name = "Apple", Price = 0.80 },
                new Product { Name = "Banana", Price = 0.30 },
                new Product { Name = "Cherry", Price = 3.80 }
                };

            products.Add(new Product { Name = "Berries", Price = 2.99 });

            List<Product> cheapProducts = products.Where(p => p.Price < 1.0).ToList();

            Console.WriteLine("Available Products: ");

            foreach (Product product in cheapProducts)
            {
                Console.WriteLine($"Product name: {product.Name} for price {product.Price}");
            }


            /* Lists
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
            */
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
