namespace DateTimeT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ceiling: " + Math.Ceiling(15.3));
            Console.WriteLine("Floor: " + Math.Floor(15.3));

            int num1 = 13;
            int num2 = 9;
            Console.WriteLine("Max: " + Math.Max(num1, num2));
            Console.WriteLine("Min: " + Math.Min(num1, num2));
            

            DateTime dateTime = new DateTime(2025, 8, 5);

            Console.WriteLine("My birthday is {0}", dateTime);

            Console.WriteLine(DateTime.Today);
            Console.WriteLine(DateTime.Now);

            DateTime tomorrow = GetTomorrow();
            Console.WriteLine("Tomorrow will be the {0}", tomorrow);
            Console.WriteLine("Today is {0}", DateTime.Today.DayOfWeek);
            Console.WriteLine(GetFirstDayOfYear(1999));

            int days = DateTime.DaysInMonth(2000, 2);
            Console.WriteLine("Days in Feb 2000: {0}", days);

            days = DateTime.DaysInMonth(2001, 2);
            Console.WriteLine("Days in Feb 2001: {0}", days);

            days = DateTime.DaysInMonth(2002, 2);
            Console.WriteLine("Days in Feb 2002: {0}", days);

            days = DateTime.DaysInMonth(2003, 2);
            Console.WriteLine("Days in Feb 2003: {0}", days);

            days = DateTime.DaysInMonth(2004, 2);
            Console.WriteLine("Days in Feb 2004: {0}", days);

            DateTime now = DateTime.Now;
            Console.WriteLine(now.Minute);

            DateTime fullClock = DateTime.Now;
            Console.WriteLine($"The time is {now.Hour} o'clock and {now.Minute} minutes and {now.Second} seconds");

            /*
            Console.WriteLine("Write a date in this format: yyyy-mm-dd");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out dateTime))
            {
                Console.WriteLine(dateTime);
                TimeSpan daysPassed = now.Subtract(dateTime);
                Console.WriteLine("Days passed since {0}: {1} days", dateTime.ToShortDateString(), daysPassed.Days);
            }

            Console.WriteLine($"Days since my birthday - {CalculateDaysSinceBirthday(Console.ReadLine())}");
            */
        }

        static DateTime GetTomorrow()
        {
            return DateTime.Today.AddDays(1);
        }

        static DateTime GetFirstDayOfYear(int year)
        {
            return new DateTime(year, 1, 1);
        }

        static int CalculateDaysSinceBirthday(string input)
        {
            DateTime.TryParse(input, out DateTime birthday);
            DateTime today = DateTime.Today;
            TimeSpan daysPassed = today - birthday;
            return daysPassed.Days;
        }
    }
}
