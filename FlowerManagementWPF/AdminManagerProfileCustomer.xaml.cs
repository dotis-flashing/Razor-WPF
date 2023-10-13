using BusinessObjects.Entity;
using Infrastructure.Service;
using System;

using System.Windows;


namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for AdminManagerProfileCustomer.xaml
    /// </summary>
    public partial class AdminManagerProfileCustomer : Window
    {
        private readonly ICustomerService _customerService;

        public AdminManagerProfileCustomer(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
            LoadDataCustomerAll();
        }

        private void LoadDataCustomerAll()
        {
            var customer = _customerService.GetCustomerAll();
            lvCustomerManager.ItemsSource = customer;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lvCustomerManager.SelectedItem = null;
            txtCustomerId.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            dpCustomerBirthday.SelectedDate = null;
            txtEmail.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtCustomerStatus.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerName = txtCustomerName.Text,
                    CustomerBirthday = dpCustomerBirthday.SelectedDate,
                    CustomerStatus = (txtCustomerStatus.Text),
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Telephone = txtTelephone.Text,
                    

                };
                var addCustomer = _customerService.Register(customer);
                LoadDataCustomerAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerId = int.Parse(txtCustomerId.Text),
                    CustomerName = txtCustomerName.Text,
                    CustomerBirthday = dpCustomerBirthday.SelectedDate,
                    Email = txtEmail.Text,
                    Telephone = txtTelephone.Text,
                    Password = txtPassword.Text,
                    CustomerStatus = txtCustomerStatus.Text,
                };
               
                var customerupdate = _customerService.updateCustomer(customer.CustomerId, customer);
                LoadDataCustomerAll();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerId = int.Parse(txtCustomerId.Text),
                };
                _customerService.Delete(customer.CustomerId);
                LoadDataCustomerAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
