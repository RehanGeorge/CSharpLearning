﻿using System.Threading.Channels;

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

            Customer.SayHi();
            Car myAudi = new Car("A3", "Audi", false);

            myAudi.Drive();

            Car myBMW = new Car("i7", "BMW", true);
            myBMW.Drive();

            // Default Customer with no Arguments given
            Customer myCustomer = new Customer();
            myCustomer.SetDetails("Frank", "Mainstreet 2", "555121312");
            myCustomer.GetDetails();

            Console.WriteLine("MyCustomer is: " + myCustomer.Name + " and he lives in " + myCustomer.Address);

            Customer secondCustomer = new Customer();
            secondCustomer.SetDetails("Rehan");
            secondCustomer.GetDetails();
            secondCustomer.Password = "12301414";

            Console.WriteLine($"secondCustomer has the following details: name - {secondCustomer.Name}, address: {secondCustomer.Address} and Contact Number: {secondCustomer.ContactNumber}");
            
            Rectangle r1 = new Rectangle("Red");
            r1.Width = 5;
            r1.Height = 5;
            Console.WriteLine($"The area of r1 is {r1.Area}");

            Rectangle r2 = new Rectangle("Blue");
            r1.DisplayDetails();
            r2.DisplayDetails();

            // Accessing the public static variable number of cars produced.
            Console.WriteLine($"Number of cars produced: {Car.NumberOfCars}");
        }
    }
}
