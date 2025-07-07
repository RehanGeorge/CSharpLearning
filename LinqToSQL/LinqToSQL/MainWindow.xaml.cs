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
            InsertStudents();
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
    }
}
