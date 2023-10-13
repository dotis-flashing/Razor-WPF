using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using Repository;
using Repository.Repository;
using Repository.Repository.Imp;
using System;
using System.Windows;

namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ICustomerService _customerService;

        public MainWindow(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var admin = _customerService.Login(txtEmail.Text, txtPassword.Password);
                if (admin == true)
                {
                    AdminManagerWindow adminManagerWindow = new AdminManagerWindow(_customerService);
                    adminManagerWindow.Show();
                }
                else if (admin == false)
                {
                    var customer = _customerService.CustomerLogin(txtEmail.Text, txtPassword.Password);
                    CustomerManagerWPF customerManagerWPF = new CustomerManagerWPF(customer.CustomerId, _customerService);
                    customerManagerWPF.Show();
                }
            }

            catch (Exception ex)
            {
                errorMessage.Text = ex.Message;
            }
        }
    }
}
