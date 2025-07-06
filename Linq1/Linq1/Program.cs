using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            UniversityManager um = new UniversityManager();

            um.MaleStudents();
            um.FemaleStudents();
            um.SortStudentsByAge();
            um.AllStudentsFromBeijingTech();

            um.StudentAndUniversityCollection();

            int[] someInt = { 30, 12, 4, 3, 12 };
            IEnumerable<int> sortedInts = from i in someInt orderby i select i;
            IEnumerable<int> reversedInts = sortedInts.Reverse();
            Console.WriteLine("Sorted Ints: " + string.Join(", ", sortedInts));
            Console.WriteLine("Reverse Sorted Ints: " + string.Join(", ", reversedInts));

            /*
            string input = Console.ReadLine();
            int inputAsInt = Convert.ToInt32(input);

            um.SearchStudentsByUniversityId(inputAsInt);
            */

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

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Alice", Gender = "female", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Bob", Gender = "male", Age = 20, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Charlie", Gender = "female", Age = 22, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "Dave", Gender = "male", Age = 21, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Ennui", Gender = "trans-gender", Age = 23, UniversityId = 1 });
        }

        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male" select student;
            Console.WriteLine("Male - Students: ");

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "female" select student;
            Console.WriteLine("Female - Students: ");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        public void SortStudentsByAge()
        {
            var sortedStudents = from student in students orderby student.Age select student;

            Console.WriteLine("Students sorted by Age:");

            foreach (Student student in sortedStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromBeijingTech()
        {
            IEnumerable<Student> bjtStudents = from student in students
                                               join university in universities on student.UniversityId equals university.Id
                                               where university.Name == "Beijing Tech"
                                               select student;

            Console.WriteLine("All Students from Beijing Tech:");
            foreach (Student student in bjtStudents)
            {
                student.Print();
            }
        }

        public void SearchStudentsByUniversityId(int universityId)
        {
            IEnumerable<Student> univStudents = from student in students
                                                join university in universities on student.UniversityId equals university.Id
                                                where university.Id == universityId
                                                select student;
            Console.WriteLine("Students from University with Id {0}:", universityId);
            foreach (Student student in univStudents)
            {
                student.Print();
            }
        }
    public void StudentAndUniversityCollection()
        {
            var newCollection = from student in students
                                join university in universities on student.UniversityId equals university.Id
                                orderby student.Name
                                select new { StudentName = student.Name, UniversityName = university.Name };

            Console.WriteLine("New Collection: ");

            foreach (var col in newCollection)
            {
                Console.WriteLine("Student: {0}, University: {1}", col.StudentName, col.UniversityName);
            }
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