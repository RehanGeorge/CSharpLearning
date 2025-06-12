using System.Data;
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

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
        }

        private void BindCurrency()
        {
            DataTable dtCurrency = new DataTable();
            dtCurrency.Columns.Add("Text");
            dtCurrency.Columns.Add("Value");

            //Add rows in the Datatable with text and value
            dtCurrency.Rows.Add("--SELECT--", 0);
            dtCurrency.Rows.Add("INR", 1);
            dtCurrency.Rows.Add("USD", 75);
            dtCurrency.Rows.Add("EUR", 85);
            dtCurrency.Rows.Add("SAR", 20);
            dtCurrency.Rows.Add("POUND", 5);
            dtCurrency.Rows.Add("DEM", 43);

            cmbFromCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbFromCurrency.DisplayMemberPath = "Text";
            cmbFromCurrency.SelectedValuePath = "Value";
            cmbFromCurrency.SelectedIndex = 0;

            cmbToCurrency.ItemsSource = dtCurrency.DefaultView;
            cmbToCurrency.DisplayMemberPath = "Text";
            cmbToCurrency.SelectedValuePath = "Value";
            cmbToCurrency.SelectedIndex = 0;
        }

        private void Convert_Click(object sender, RoutedEventArgs e)
        {
            //Create the variable as ConvertedValue with double datatype to store currency converted value
            double ConvertedValue;

            // Validate amount textbox input
            if (string.IsNullOrWhiteSpace(txtCurrency.Text))
            {
                MessageBox.Show("Please Enter Currency", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                txtCurrency.Focus();
                return;
            }

            // Validate numeric input
            if (!double.TryParse(txtCurrency.Text, out double amount) || amount < 0)
            {
                MessageBox.Show("Please enter a valid positive number for the amount.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtCurrency.Focus();
                return;
            }

            // Validate From currency selection
            if (cmbFromCurrency.SelectedValue == null || cmbFromCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency From", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbFromCurrency.Focus();
                return;
            }

            // Validate To currency selection
            if (cmbToCurrency.SelectedValue == null || cmbToCurrency.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Currency To", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                cmbToCurrency.Focus();
                return;
            }

            // Parse currency values
            if (!double.TryParse(cmbFromCurrency.SelectedValue.ToString(), out double fromValue) ||
                !double.TryParse(cmbToCurrency.SelectedValue.ToString(), out double toValue) ||
                toValue == 0)
            {
                MessageBox.Show("Invalid currency selection.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Conversion logic
            if (cmbFromCurrency.Text == cmbToCurrency.Text)
            {
                ConvertedValue = amount;
            }
            else
            {
                ConvertedValue = (fromValue * amount) / toValue;
            }

            // Show the result
            lblCurrency.Content = $"{cmbToCurrency.Text} {ConvertedValue:N3}";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            lblCurrency.Content = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }

        private void ClearControls()
        {
            txtCurrency.Text = string.Empty;
            if (cmbFromCurrency.Items.Count > 0)
                cmbFromCurrency.SelectedIndex = 0;
            if (cmbToCurrency.Items.Count > 0)
                cmbToCurrency.SelectedIndex = 0;
            lblCurrency.Content = string.Empty;
            txtCurrency.Focus();
        }
    }
}