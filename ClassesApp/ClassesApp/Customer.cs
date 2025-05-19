using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class Customer
    {
        private static int nextId = 0;

        private readonly int _id;

        private string _password;

        public string Password { set
            {
                _password = value;
            } }

        // Read Only Property
        public int Id
        {
            get
            {
                return _id;
            }
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        // Default Customer
        public Customer()
        {
            _id = nextId++;
            Name = "DefaultName";
            Address = "No Address";
            ContactNumber = "No Contact Number";
        }

        // Custom Constructor
        public Customer(string name, string address, string contactNumber)
        {
            _id = nextId++;
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }

        public Customer(string name)
        {
            _id = nextId++;
            Name = name;
        }

        public void SetDetails(string name, string address = "NA", string contactNumber = "NA")
        {
            Name = name;
            Address = address;
            ContactNumber = contactNumber;
        }

        public void GetDetails()
        {
            Console.WriteLine($"Details about the customer {Name}. Id is {Id}");
        }

        public static void SayHi()
        {
            Console.WriteLine("Hi from the customer class");
        }
    }
}
