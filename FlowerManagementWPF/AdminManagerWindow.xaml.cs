using Infrastructure.Service;
using System.Windows;


namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for AdminManagerWindow.xaml
    /// </summary>
    public partial class AdminManagerWindow : Window
    {
        private readonly ICustomerService _customerService;
        private readonly IManuFactureService _manuFactureService;
        private readonly ISupplierService _supplierService;
        private readonly ICarService _carService;

        public AdminManagerWindow(ICustomerService customerService, IManuFactureService manuFactureService, ISupplierService supplierService)
        {
            InitializeComponent();
            _customerService = customerService;
            _manuFactureService = manuFactureService;
            _supplierService = supplierService;
        }

        private void btnManagerCustomerProfile_Click(object sender, RoutedEventArgs e)
        {
            AdminManagerProfileCustomer customer = new AdminManagerProfileCustomer(_customerService);
            customer.Show();
        }



        private void btnManagerCar_Click(object sender, RoutedEventArgs e)
        {
            ManagerCarWindow managerCarWindow = new ManagerCarWindow(_supplierService, _carService, _manuFactureService);
            managerCarWindow.Show();
        }
    }
}
