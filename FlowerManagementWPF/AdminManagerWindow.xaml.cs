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

        public AdminManagerWindow(ICustomerService customerService)
        {
            InitializeComponent();
            _customerService = customerService;
        }

        private void btnManagerCustomerProfile_Click(object sender, RoutedEventArgs e)
        {
            AdminManagerProfileCustomer customer= new AdminManagerProfileCustomer(_customerService);
            customer.Show();
        }

    

        private void btnManagerCar_Click(object sender, RoutedEventArgs e)
        {
            ManagerCarWindow managerCarWindow = new ManagerCarWindow();
            managerCarWindow.Show();
        }
    }
}
