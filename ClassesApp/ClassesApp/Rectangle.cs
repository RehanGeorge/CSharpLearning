using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesApp
{
    internal class Rectangle
    {

        public const int NumberOfCorners = 4;
        public readonly string Color;

        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(string color)
        {
            Color = color;
        }
        // Computed property
        public double Area
        {
            get
            {
                return Width * Height;
            }
        }

        public void DisplayDetails()
        {
            Console.WriteLine($"Color: {Color}, Width: {Width}, Height: {Height}, Area: {Area}, Number of Corners: {NumberOfCorners}");
        }
    }
}
