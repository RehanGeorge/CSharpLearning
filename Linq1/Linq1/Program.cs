using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            OddEvenNumbers(numbers);

        }

        static void OddEvenNumbers(int[] numbers)
        {
            IEnumerable<int> oddNumbers = numbers.Where(n => n % 2 != 0);
            Console.WriteLine($"Odd Numbers: {string.Join(", ", oddNumbers)}");
            IEnumerable<int> evenNumbers = from number in numbers where number % 2 == 0 select number;
            //Console.WriteLine($"Odd Numbers: {oddNumbers}");
            Console.WriteLine($"Even Numbers: {string.Join(", ", evenNumbers)}");
        }
    }
}
