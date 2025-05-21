using System.Drawing;

namespace ListsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Declaring a list and initializing
            List<string> colors = ["red", "blue", "green", "red"];

            printColors(colors);

            while (colors.Remove("red") == true)
            {
                Console.WriteLine("Deleted 1 red");
            }

            printColors(colors);
        }

        private static void printColors(List<string> colors)
        {
            Console.WriteLine("Current colors in the colors list!");
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
        }
    }
}
