using Infrastructure.Service;
using System.Windows;


namespace FlowerManagementWPF
{
    public partial class TransactionHistoryWindow : Window
    {
        private readonly IRentingTransactionService _transactionService;
        private int customerId;

        public TransactionHistoryWindow(IRentingTransactionService transactionService, int customerId)
        {
            InitializeComponent();
            _transactionService = transactionService;
            this.customerId = customerId;

        }

        private void RentingHistory(object sender, RoutedEventArgs e)
        {
            var rentingTransaction = _transactionService.GetRentingTransactionByCustomerID(customerId);
            listHistory.ItemsSource = rentingTransaction;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
