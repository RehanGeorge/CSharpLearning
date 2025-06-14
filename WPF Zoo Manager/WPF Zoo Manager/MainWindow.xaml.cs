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
    }
}