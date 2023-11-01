using Infrastructure.Service;
using Infrastructure.Service.Implement;
using System.Windows;


namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for CustomerManagerWPF.xaml
    /// </summary>
    public partial class CustomerManagerWPF : Window
    {
        public int customerId;
        private readonly ICustomerService _customerService;
        private readonly IRentingTransactionService _transactionService;

        public CustomerManagerWPF(int customerId, ICustomerService customerService, IRentingTransactionService transactionService)
        {
            InitializeComponent();

            this.customerId = customerId;
            _customerService = customerService;
            _transactionService = transactionService;
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            var customer = _customerService.Profile(customerId);
            if (customer != null)
            {
                CustomerProfileWindow customerProfileWindow = new CustomerProfileWindow(customer.CustomerId, _customerService);
                customerProfileWindow.Show();
            }
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            TransactionHistoryWindow rentingTransactionWindow = new TransactionHistoryWindow(_transactionService, customerId);
            rentingTransactionWindow.Show();
        }

        private void btnRenting_Click(object sender, RoutedEventArgs e)
        {
            RentingTransactionWindow rentingTransactionWindow = new RentingTransactionWindow(_transactionService, customerId);
            rentingTransactionWindow.Show();
        }
    }
}
