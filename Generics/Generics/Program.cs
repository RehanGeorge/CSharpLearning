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
        }
    }
}
