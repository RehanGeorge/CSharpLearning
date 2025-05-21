namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            employees.Add(1, new Employee("John Doe", 35, 100000));
            employees.Add(2, new Employee("John Does", 55, 200000));
            employees.Add(3, new Employee("John Doesnt", 45, 80000));
            employees.Add(4, new Employee("John Wasnt", 15, 100000));
            employees.Add(5, new Employee("John Was", 25, 100000));

            foreach (var item in employees)
            {
                Console.WriteLine($"ID is {item.Key} with Name: {item.Value.Name}, age: {item.Value.Age} and salary: {item.Value.Salary}");
            }

            /* Initiate dictionaries
            Dictionary<int, string> employees = new Dictionary<int, string>();

            employees.Add(101, "John Doe");
            employees.Add(102, "Bob Smith");
            employees.Add(103, "Rob Smith");
            employees.Add(104, "Flob Smith");
            employees.Add(105, "Dob Smith");
            employees.Add(106, "Cob Smith");

            // Access items in a dictionary
            string name = employees[101];
            Console.WriteLine(name);

            // Update data in a dictionary
            employees[102] = "Jane Smith";

            // Remove an item from a dictionary
            employees.Remove(100);

            employees[104] = "Mike Jike";

            if(!employees.ContainsKey(104))
            {
                employees.Add(104, "Mike Jike");
            }

            bool added = employees.TryAdd(102, "Michal Brims");
            if (!added)
            {
                Console.WriteLine("An employee already exists here.");
            }

            foreach (KeyValuePair<int, string> employee in employees)
            {
                Console.WriteLine($"ID: {employee.Key}, Name: {employee.Value}");
            }

            */

            /* Nullables
            int? age = null; // int? is a nullable int
            int myAge = 32;

            if (age.HasValue)
            {
                Console.WriteLine("Age is " + age.Value);
                int sum = age.Value + myAge;
            }
            else
            {
                Console.WriteLine("Age is not specified.");
            }
            */

            /* Products
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
            */

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
