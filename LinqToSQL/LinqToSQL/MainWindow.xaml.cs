using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace LinqToSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqToSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["LinqToSQL.Properties.Settings.CSharpLearningDBConnectionString"].ConnectionString;
            dataContext = new LinqToSqlDataClassesDataContext(connectionString);

            //InsertUniversities();
            //InsertStudents();
            //InsertLectures();
            //InsertStudentLectureAssociations();
            //GetUniversityOfStudent("Jane Smith");
            //GetLecturesFromStudent("John Doe");
            //GetAllStudentsFromYale();
            //GetAllLecturesFromHarvard();
            //UpdateStudentName("John Doe", "Johnathan Doe");
        }

        public void InsertUniversities()
        {
            dataContext.ExecuteCommand("delete from University");

            University yale = new University
            {
                Name = "Yale"
            };
            dataContext.Universities.InsertOnSubmit(yale);

            University harvard = new University();
            harvard.Name = "Harvard";

            dataContext.Universities.InsertOnSubmit(harvard);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Universities.ToList();
        }

        public void InsertStudents()
        {
            University yale = dataContext.Universities.First(un => un.Name.Equals("Yale"));
            University harvard = dataContext.Universities.First(un => un.Name.Equals("Harvard"));

            List<Student> students = new List<Student>();

            students.Add(new Student { Name = "John Doe", Gender = "Male", UniversityId = yale.Id });
            students.Add(new Student { Name = "Jane Smith", Gender = "Female", University = harvard });
            students.Add(new Student { Name = "Alice Johnson", Gender = "Female", UniversityId = yale.Id });
            students.Add(new Student { Name = "Bob Brown", Gender = "Male", UniversityId = harvard.Id });

            dataContext.Students.InsertAllOnSubmit(students);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void InsertLectures()
        {
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Math" });
            dataContext.Lectures.InsertOnSubmit(new Lecture { Name = "Physics" });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Lectures;
        }

        public void InsertStudentLectureAssociations()
        {
            Student jd = dataContext.Students.First(s => s.Name.Equals("John Doe"));
            Student js = dataContext.Students.First(s => s.Name.Equals("Jane Smith"));
            Student aj = dataContext.Students.First(s => s.Name.Equals("Alice Johnson"));
            Student bb = dataContext.Students.First(s => s.Name.Equals("Bob Brown"));

            Lecture math = dataContext.Lectures.First(l => l.Name.Equals("Math"));
            Lecture physics = dataContext.Lectures.First(l => l.Name.Equals("Physics"));

            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = jd, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = js, Lecture = physics });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = aj, Lecture = math });
            dataContext.StudentLectures.InsertOnSubmit(new StudentLecture { Student = bb, Lecture = physics });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.StudentLectures.ToList();
        }

        public void GetUniversityOfStudent(string studentName)
        {
            Student student = dataContext.Students.FirstOrDefault(s => s.Name.Equals(studentName));

            University university = student?.University;

            List<University> universities = new List<University>();
            universities.Add(university);

            MainDataGrid.ItemsSource = universities;
        }

        public void GetLecturesFromStudent(string studentName)
        {
            Student student = dataContext.Students.FirstOrDefault(s => s.Name.Equals(studentName));
            if (student != null)
            {
                var lectures = from sl in dataContext.StudentLectures
                               where sl.StudentId == student.Id
                               select sl.Lecture;
                MainDataGrid.ItemsSource = lectures.ToList();
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
        }

        public void GetAllStudentsFromYale()
        {
            var studentsFromYale = from s in dataContext.Students
                                   where s.University.Name == "Yale"
                                   select s;

            MainDataGrid.ItemsSource = studentsFromYale.ToList();
        }

        public void GetAllLecturesFromHarvard()
        {
            var lecturesFromHarvard = from sl in dataContext.StudentLectures
                                      join s in dataContext.Students on sl.StudentId equals s.Id
                                      where s.University.Name == "Harvard"
                                      select sl.Lecture;
            List<Lecture> uniqueLectures = lecturesFromHarvard.Distinct().ToList();
            MainDataGrid.ItemsSource = uniqueLectures;
        }

        public void UpdateStudentName(string currentName, string newName)
        {
            Student student = dataContext.Students.FirstOrDefault(s => s.Name.Equals(currentName));
            if (student != null)
            {
                student.Name = newName;
                dataContext.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Student not found.");
            }

            MainDataGrid.ItemsSource = dataContext.Students;
        }

        public void DeleteStudent(string studentName)
        {
            Student student = dataContext.Students.FirstOrDefault(s => s.Name.Equals(studentName));
            if (student != null)
            {
                dataContext.Students.DeleteOnSubmit(student);
                dataContext.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Student not found.");
            }
            MainDataGrid.ItemsSource = dataContext.Students;
        }
    }
}
