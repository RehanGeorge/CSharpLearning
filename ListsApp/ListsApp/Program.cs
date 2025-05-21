using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing
            List<string> colors = new List<string>();

            colors.Add("red");
            colors.Add("blue");
            colors.Add("green");

            Console.WriteLine("Current colors in the colors list!");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
        }
    }
}
