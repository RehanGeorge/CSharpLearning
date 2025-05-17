﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class Car
    {
        // member variable
        // private hides the variable from other classes
        private string _model = "";
        private string _brand = "";

        // Constructor
        public Car(string model, string brand)
        {
            Model = model;
            Brand = brand;
            Console.WriteLine($"A {Brand} of the model {Model} has been created.");
        }

        public string Model { get => _model; set => _model = value; }
        public string Brand { get => _brand; set => _brand = value; }
    }
}
