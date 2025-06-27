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
            ShowAllAnimals();
        }

        private void LoadAnimals()
        {
            using (var context = new ZooContext())
            {
                var animals = context.Animals.ToList();
                Console.WriteLine("Animals loaded from database:");
                // Bind 'animals' to your UI, e.g., DataGrid
            }
        }

        private void ShowAllAnimals()
        {
            try
            {
                string query = "select * from Animal";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString);

                using (sqlDataAdapter)
                {
                    DataTable animalTable = new DataTable();
                    sqlDataAdapter.Fill(animalTable);

                    listAllAnimals.DisplayMemberPath = "Name";
                    listAllAnimals.SelectedValuePath = "Id";
                    listAllAnimals.ItemsSource = animalTable.DefaultView;
                }
            }
            catch (Exception)
            {
                throw;
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
                string query = "SELECT * FROM Animal a INNER JOIN ZooAnimal za ON a.Id = za.AnimalId WHERE za.ZooId = @ZooId";

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
            ShowSelectedZooInTextBox();
        }

        private void listAnimals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowSelectedAnimalInTextBox();
        }

        private void DeleteZoo_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM Zoo WHERE id = @ZooId";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void AddZoo_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Zoo values (@Location)";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void addAnimalToZoo_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO ZooAnimal values (@ZooId, @AnimalId)";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAssociatedAnimals();
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            string query = "DELETE FROM Animal WHERE id = @AnimalId";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void ShowSelectedZooInTextBox()
        {
            try
            {
                string query = "SELECT location FROM Zoo WHERE Id = @ZooId";

                string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                    DataTable zooDataTable = new DataTable();

                    sqlDataAdapter.Fill(zooDataTable);

                    myTextBox.Text = zooDataTable.Rows[0]["Location"].ToString();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void ShowSelectedAnimalInTextBox()
        {
            try
            {
                string query = "SELECT Name FROM Animal WHERE Id = @AnimalId";
                string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable animalDataTable = new DataTable();
                    sqlDataAdapter.Fill(animalDataTable);
                    myTextBox.Text = animalDataTable.Rows[0]["Name"].ToString();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            string query = "INSERT INTO Animal values (@Name)";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }

        private void updateZoo_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE Zoo SET Location = @Location WHERE Id = @ZooId";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@ZooId", listZoos.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Location", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowZoos();
            }
        }

        private void UpdateAnimal_Click(object sender, RoutedEventArgs e)
        {
            string query = "UPDATE Animal SET Name = @Name WHERE Id = @AnimalId";
            string connectionString = ConfigurationManager.ConnectionStrings["ZooDbConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            
            try
            {
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@AnimalId", listAllAnimals.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@Name", myTextBox.Text);
                sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sqlConnection.Close();
                ShowAllAnimals();
            }
        }
    }
}