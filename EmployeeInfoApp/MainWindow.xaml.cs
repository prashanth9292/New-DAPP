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
using EmployeeInfoApp.EmployeeServiceProxy;
using System.ServiceModel;

namespace EmployeeInfoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EmployeeServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
            client = new EmployeeServiceClient();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int findMgId = Convert.ToInt32(txtManagerId.Text);
                if (txtManagerId.Text != null && client.FindEmployee(findMgId) == null)
                    throw new Exception("Invalid Manager Id! Enter a valid value.");
                Employee employee = layoutRoot.DataContext as Employee;
                client.InsertEmployee(employee);
            }
            catch (FaultException ex)
            {
                MessageBox.Show($"Exception: {ex.Message}");
            }
            catch(Exception ex)
            {
                txtManagerId.Clear();
                txtManagerId.Focus();
                MessageBox.Show($"Exception: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int findMgId = Convert.ToInt32(txtManagerId.Text);
                if (txtManagerId.Text != null && client.FindEmployee(findMgId) == null)
                    throw new Exception("Invalid Manager Id! Enter a valid value.");
                Employee employee = layoutRoot.DataContext as Employee;
                client.UpdateEmployee(employee);
            }
            catch (FaultException ex)
            {
                lblException.Text = ($"Exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                txtManagerId.Clear();
                txtManagerId.Focus();
                lblException.Text = ($"Exception: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            layoutRoot.DataContext = new Employee();
            txtEmployeeId.Focus();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int id = Int32.Parse(txtEmployeeId.Text);
            try
            {
                client.DeleteEmployee(id);
            }
            catch (FaultException ex)
            {
                lblException.Text = ($"Exception: {ex.Message}");
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Int32.Parse(txtEmployeeId.Text);
                Employee employee = client.FindEmployee(id);
                if (employee==null)
                {
                    MessageBox.Show("Employee not found!");
                }
                layoutRoot.DataContext = employee;
            }
            catch (FaultException ex)
            {
                lblException.Text = ($"Exception: {ex.Message}");
            }
        }
    }
}
