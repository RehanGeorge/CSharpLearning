using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Zoo_Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadAnimals();
            ShowZoos();
        }

        private void LoadAnimals()
        {
            using (var context = new ZooContext())
            {
                var animals = context.Animals.ToList();
                Console.WriteLine("Animals loaded from database:");
                MessageBox.Show($"Loaded {animals.Count} animals from the database.", "Zoo Manager", MessageBoxButton.OK, MessageBoxImage.Information);
                // Bind 'animals' to your UI, e.g., DataGrid
            }
        }

        private void ShowZoos()
        {
            try
            {
                string query = "SELECT * FROM Zoo";
                string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connectionString);


                using (sqlDataAdapter)
                {
                    DataTable zooTable = new DataTable();

                    sqlDataAdapter.Fill(zooTable);

                    listZoos.DisplayMemberPath = "Location";
                    listZoos.SelectedValuePath = "Id";
                    listZoos.ItemsSource = zooTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowAssociatedAnimals()
        {
            try
            {
                string query = "SELECT * FROM Animals a INNER JOIN ZooAnimal za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId";

                string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                    
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    
                    DataTable animalTable = new DataTable();

                    sqlDataAdapter.Fill(animalTable);

                    listAssociatedAnimals.DisplayMemberPath = "Name";
                    listAssociatedAnimals.SelectedValuePath = "Id";
                    listAssociatedAnimals.ItemsSource = animalTable.DefaultView;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void listZoos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowAssociatedAnimals();
        }
    }
}