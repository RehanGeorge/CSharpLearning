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

            foreach (int i in oddNumbers)
            {
                Console.WriteLine($"Odd Number: {i}");
            }
        }
    }

    class UniversityManager
    {
        public List<University> universities;
        public List<Student> students;

        public UniversityManager()
        {
            universities = new List<University>();
            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "University A" });
            universities.Add(new University { Id = 2, Name = "University B" });

            students.Add(new Student { Id = 1, Name = "Alice", Gender = "female", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Bob", Gender = "male", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Charlie", Gender = "male", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Dave", Gender = "male", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Ennui", Gender = "female", Age = 23, UniversityId = 1 });
        }
    }
    class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("University {0} with id {1}", Name, Id);
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId { get; set; }
        public void Print()
        {
            Console.WriteLine("Student {0} with Id {1}, Gender {2} and Age {3} from University with the Id {4}", Name, Id, Gender, Age, UniversityId);
        }
    }
}