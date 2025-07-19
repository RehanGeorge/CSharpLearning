using System.Reflection;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<int> intBox = new Box<int>();
            intBox.Content = 42;
            Console.WriteLine(intBox.Log());

            Box<string> stringBox = new Box<string>();
            stringBox.Content = "Hello, Generics!";
            Console.WriteLine(stringBox.Log());

            NewBox<double> doubleBox = new NewBox<double>(3.14);
            doubleBox.UpdateContent(2.71);
            Console.WriteLine(doubleBox.Value);

            MultiBox<int, string> multiBox = new MultiBox<int, string>(1, "One");
            multiBox.Display();

            Logger logger = new Logger();

            logger.Log<int>(10);
            logger.Log<string>("Hello World");

            logger.Log(new {Name = "John", Age = 30});

            Repository<Product> repository = new Repository<Product>();
            var product = new Product();
            repository.Add(product);

            var product2 = new Product();
            Console.WriteLine(Comparer.AreEqual(product, product2));

            Type type = typeof(Product);

            Action action = () => Console.WriteLine("Action executed");
            MethodInfo methodInfo = action.GetMethodInfo();
            action.Invoke();
            action();

            Action<int> numPrint = x =>
            {
                Console.WriteLine(x);
            };

            numPrint(5);

            Action<float,float,float> sum = (x, y, z) =>
            {
                Console.WriteLine(x + y + z);
            };

            sum(1.5f, 2.5f, 3.5f);
        }
    }


}
