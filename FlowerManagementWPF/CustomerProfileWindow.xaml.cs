using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using System.Windows;


namespace FlowerManagementWPF
{

    public partial class CustomerProfileWindow : Window
    {
        public int customerId;
        private readonly ICustomerService _customerService;

        public CustomerProfileWindow(int customerId, ICustomerService customerService)
        {
            InitializeComponent();
            this.customerId = customerId;
            _customerService = customerService;
        }

        private void CustomerProfileLoad(object sender, RoutedEventArgs e)
        {
            var customer = _customerService.Profile(customerId);

            inputCustomerId.Text = customer.CustomerId.ToString();
            txtEmail.Text = customer.Email.ToString();
            txtName.Text = customer.CustomerName.ToString();
            txtBirthday.Text = customer.CustomerBirthday.ToString();
            txtPhone.Text = customer.Telephone.ToString();
            txtPassword.Text = customer.Password.ToString();

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer
            {
                CustomerId = int.Parse(inputCustomerId.Text),
                CustomerName = txtName.Text,
                Email = txtEmail.Text,
                Telephone = txtPhone.Text,
                Password = txtPassword.Text,
            };
            var customerupdate = _customerService.updateCustomer(customerId, customer);

        }
    }
}
