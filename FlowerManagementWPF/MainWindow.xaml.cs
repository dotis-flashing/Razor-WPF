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
        private readonly IRentingTransactionService _transactionService;
        private readonly ICustomerService _customerService;
        private readonly IManuFactureService _manuFactureService;
        private readonly ISupplierService _supplierService;
        private readonly ICarService _carService;

        public MainWindow(IRentingTransactionService transactionService, ICustomerService customerService, IManuFactureService manuFactureService, ISupplierService supplierService, ICarService carService)
        {
            InitializeComponent();
            _transactionService = transactionService;
            _customerService = customerService;
            _manuFactureService = manuFactureService;
            _supplierService = supplierService;
            _carService = carService;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var admin = _customerService.Login(txtEmail.Text, txtPassword.Password);
                if (admin == true)
                {
                    AdminManagerWindow adminManagerWindow = new AdminManagerWindow(_customerService, _manuFactureService, _supplierService);
                    adminManagerWindow.Show();
                }
                else if (admin == false)
                {
                    var customer = _customerService.CustomerLogin(txtEmail.Text, txtPassword.Password);
                    CustomerManagerWPF customerManagerWPF = new CustomerManagerWPF(customer.CustomerId, _customerService, _transactionService);
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
