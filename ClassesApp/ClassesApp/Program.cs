using System.Threading.Channels;

namespace ClassesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Car audi = new Car("A3", "Audi", false);
            Car bmw = new Car("i7", "BMW", true);

            // Getting Brand
            Console.WriteLine($"Brand is " + audi.Brand);
            Console.WriteLine($"Brand is " + bmw.Brand);

            Customer earl = new Customer("Earl");
            Customer frankTheTank = new Customer("FrankTheTank", "Mainstreet 1", "5551234556");

            Console.WriteLine("Name of Customer is " + earl.Name);
            // Default Customer with no Arguments given
            Customer myCustomer = new Customer();
            
            Console.WriteLine("Details about customer: " + myCustomer.Name);
            myCustomer.Name = "Jimbo";
            Console.WriteLine(myCustomer.Name);
            */

            Car myAudi = new Car("A3", "Audi", false);

            myAudi.Drive();

            Car myBMW = new Car("i7", "BMW", true);
            myBMW.Drive();
        }
    }
}
