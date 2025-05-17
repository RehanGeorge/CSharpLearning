using System.Threading.Channels;

namespace ClassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car audi = new Car("A3", "Audi", false);
            Car bmw = new Car("i7", "BMW", true);

            // Getting Brand
            Console.WriteLine($"Brand is " + audi.Brand);
            Console.WriteLine($"Brand is " + bmw.Brand);
        }
    }
}
