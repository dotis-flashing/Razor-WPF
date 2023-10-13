using BusinessObjects.Entity;
using Infrastructure.Service;
using System;

using System.Windows;


namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for RentingTransactionWindow.xaml
    /// </summary>
    public partial class RentingTransactionWindow : Window
    {
        private readonly IRentingTransactionService _transactionService;
        private int customerId;

        public RentingTransactionWindow(IRentingTransactionService transactionService, int customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
            _transactionService = transactionService;
            LoadRentingHistory();

        }
        private void LoadRentingHistory()
        {
            var rentingTransaction = _transactionService.GetRentingTransactionByCustomerID(customerId);
            lvRentingManagerCustomer.ItemsSource = rentingTransaction;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RentingTransaction rentingTransaction = new RentingTransaction
                {
                    RentingDate = dpCustomerBirthday.SelectedDate,
                    RentingStatus = (txtRentingStatus.Text),
                    TotalPrice = decimal.Parse(txtTotalPrice.Text),
                    CustomerId = customerId,

                };
                var addCustomer = _transactionService.AddRenting(rentingTransaction);
                LoadRentingHistory();
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
                RentingTransaction rentingTransaction = new RentingTransaction
                {
                    RentingTransationId = int.Parse(txtRentingTransationId.Text)
                };
                _transactionService.DeleteRenting(rentingTransaction.RentingTransationId);
                LoadRentingHistory();
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

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RentingTransaction rentingTransaction = new RentingTransaction
                {
                    RentingTransationId = int.Parse(txtRentingTransationId.Text),
                    CustomerId = customerId,
                    TotalPrice=decimal.Parse(txtTotalPrice.Text),
                    RentingStatus=(txtRentingStatus.Text),
                    RentingDate = dpCustomerBirthday.SelectedDate
                    
                };
                _transactionService.UpdateRenting(rentingTransaction.RentingTransationId, rentingTransaction);
                LoadRentingHistory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
           lvRentingManagerCustomer.SelectedItem= null;
            txtCustomerId.Text= string.Empty;
            txtRentingStatus.Text= string.Empty;
            txtTotalPrice.Text= string.Empty;
            txtRentingTransationId.Text = string.Empty;
        }
    }
}
