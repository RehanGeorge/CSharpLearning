using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        private int CurrencyId = 0; // Variable to hold the CurrencyId
        private double FromAmount = 0; // Variable to hold the FromAmount
        private double ToAmount = 0; // Variable to hold the ToAmount

        public MainWindow()
        {
            InitializeComponent();
            BindCurrency();
            ClearMaster();
        }

        public void mycon()
        {
            String Conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(Conn);
            con.Open();
        }

        private void BindCurrency()
        {
            mycon();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT Id, CurrencyName from Currency_Master", con);
            cmd.CommandType = CommandType.Text;

            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            // Add a new row for the default selection
            DataRow newRow = dt.NewRow();
            newRow["id"] = 0;
            newRow["CurrencyName"] = "Select Currency";

            // Insert the new row at the beginning of the DataTable
            dt.Rows.InsertAt(newRow, 0);

            if (dt != null && dt.Rows.Count > 0)
            {
                cmbFromCurrency.ItemsSource = dt.DefaultView;
                cmbToCurrency.ItemsSource = dt.DefaultView;
            }
            con.Close();

            
            cmbFromCurrency.DisplayMemberPath = "CurrencyName";
            cmbFromCurrency.SelectedValuePath = "Id";
            cmbFromCurrency.SelectedIndex = 0;


            cmbToCurrency.DisplayMemberPath = "CurrencyName";
            cmbToCurrency.SelectedValuePath = "Id";
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
            ClearControls();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtAmount.Text == null || txtAmount.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter amount", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtAmount.Focus();
                    return;
                }
                else if (txtCurrencyName.Text == null || txtCurrencyName.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter currency name", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCurrencyName.Focus();
                    return;
                }
                else
                {
                    if (CurrencyId > 0)
                    {
                        if (MessageBox.Show("Are you sure you want to update this currency?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            cmd = new SqlCommand("UPDATE Currency_Master SET Amount = @Amount, CurrencyName = @CurrencyName WHERE Id = @Id", con);
                            cmd.Parameters.AddWithValue("@Id", CurrencyId);
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text.Trim());
                            cmd.ExecuteNonQuery();
                            con.Close();

                            MessageBox.Show("Currency updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else
                    {
                        if (MessageBox.Show("Are you sure you want to save this currency?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            mycon();
                            cmd = new SqlCommand("INSERT INTO Currency_Master (Amount, CurrencyName) VALUES (@Amount, @CurrencyName)", con);
                            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
                            cmd.Parameters.AddWithValue("@CurrencyName", txtCurrencyName.Text.Trim());
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Currency saved successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        ClearMaster();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearMaster() // his method clears the master data fields
        {
            try
            {
                txtAmount.Text = string.Empty;
                txtCurrencyName.Text = string.Empty;
                btnSave.Content = "Save";
                GetData();
                CurrencyId = 0;
                BindCurrency();
                txtAmount.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetData()
        {
            try
            {
                mycon();
                cmd = new SqlCommand("SELECT Id, Amount, CurrencyName FROM Currency_Master", con);
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvCurrency.Visibility = Visibility.Visible;
                    dgvCurrency.ItemsSource = dt.DefaultView;
                }
                else
                {
                    dgvCurrency.Visibility = Visibility.Collapsed;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgvCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgvCurrency_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }
    }
}