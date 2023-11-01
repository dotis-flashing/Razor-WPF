using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using System;
using System.Windows;

namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for SupplierManagerWindow.xaml
    /// </summary>
    public partial class SupplierManagerWindow : Window
    {
        private readonly ISupplierService _supplierService;
        private readonly IManuFactureService _manuFactureService;
      

        public SupplierManagerWindow(ISupplierService supplierService, IManuFactureService manuFactureService)
        {
            InitializeComponent();
            _supplierService = supplierService;
            _manuFactureService = manuFactureService;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var supplier = _supplierService.GetSuppliersAll();
                lvManagerSupplier.ItemsSource = supplier;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier
                {
                    SupplierAddress = txtSupplierAddress.Text,
                    SupplierName = txtSupplierName.Text,
                    SupplierDescription = txtSupplierDescription.Text,
                };
                _supplierService.AddSupplier(supplier);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtSupplierAddress.Text = string.Empty;
            txtSupplierDescription.Text = string.Empty;
            txtSupplierId.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Supplier supplier = new Supplier
                {
                    SupplierAddress = txtSupplierAddress.Text,
                    SupplierName = txtSupplierName.Text,
                    SupplierDescription = txtSupplierDescription.Text,
                    SupplierId = int.Parse(txtSupplierId.Text),
                };
                _supplierService.UpdateSupplier(supplier.SupplierId, supplier);
                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddManufacture_Click(object sender, RoutedEventArgs e)
        {
            ManuFactureManagerWindo manuFactureManagerWindo = new ManuFactureManagerWindo(_manuFactureService);
            manuFactureManagerWindo.Show();
        }
    }
}
