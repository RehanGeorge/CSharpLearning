namespace StructsApp
{

    public struct Point
    {
        public double X { get; }
        public double Y { get; }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"Point: ({X}, {Y})");
        }

        public double DistanceTo(Point other)
        {
            double deltaX = other.X - X;
            double deltaY = other.Y - Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

    }

    enum Day { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
    enum Month { Jan = 1, Feb, Mar, Apr, May, Jun, Jul = 12, Aug, Sep, Oct, Nov, Dec };
    internal class Program
    {
        static void Main(string[] args)
        {
            Point p1 = new Point(10, 20);
            p1.Display();

            Point p2 = new Point(20, 30);
            p2.Display();

            double distance = p1.DistanceTo(p2);
            Console.WriteLine($"Distance between points: {distance:F2}");

            Point p3 = p1;

            Day fr = Day.Friday;
            Day su = Day.Sunday;

            Day a = Day.Friday;

            Console.WriteLine(fr == a);
            Console.WriteLine(su);
            Console.WriteLine((int)Day.Monday);

            Console.WriteLine((int)Month.Feb);
            Console.WriteLine((int)Month.Aug);
        }
    }
}
