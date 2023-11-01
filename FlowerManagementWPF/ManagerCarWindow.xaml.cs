using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using System;
using System.Linq;

using System.Windows;


namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for ManagerCarWindow.xaml
    /// </summary>
    public partial class ManagerCarWindow : Window
    {
        private readonly ISupplierService _supplierService;
        private readonly ICarService _carService;
        private readonly IManuFactureService _manuFactureService;

        public ManagerCarWindow(ISupplierService supplierService, ICarService carService, IManuFactureService manuFactureService)
        {
            InitializeComponent();
            _supplierService = supplierService;
            _carService = carService;
            _manuFactureService = manuFactureService;
            LoadData();

        }



        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierManagerWindow supp = new SupplierManagerWindow(_supplierService, _manuFactureService);
            supp.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadData()
        {
            lvManagerCar.ItemsSource = _carService.GetCarInformationAll();
            var manu = _manuFactureService.GetManufacturersAll();
            cboManuFa.ItemsSource = manu.Select(e => e.ManufacturerId);
            var supllier = _supplierService.GetSuppliersAll();
            cboSupplierId.ItemsSource = supllier.Select(c => c.SupplierId);
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CarInformation carInformation = new CarInformation
                {
                    CarDescription = txtCarDescription.Text,
                    CarName = txtCarName.Text,
                    CarRentingPricePerDay = decimal.Parse(txtCarRentingPricePerDay.Text),
                    FuelType = txtFuelType.Text,
                    CarStatus = "ACTIVE",
                    ManufacturerId = int.Parse(cboManuFa.Text),
                    NumberOfDoors = int.Parse(txtNumberOfDoors.Text),
                    SeatingCapacity = int.Parse(txtSeatingCapacity.Text),
                    SupplierId = int.Parse(cboSupplierId.Text),
                    Year = int.Parse(txtYear.Text),
                };
                _carService.AddCar(carInformation);
                LoadData();
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
                CarInformation carInformation = new CarInformation
                {
                    CarId = int.Parse(txtCarId.Text),
                    CarDescription = txtCarDescription.Text,
                    CarName = txtCarName.Text,
                    CarRentingPricePerDay = decimal.Parse(txtCarRentingPricePerDay.Text),
                    FuelType = txtFuelType.Text,
                    ManufacturerId = int.Parse(cboManuFa.Text),
                    CarStatus = "ACTIVE",
                    NumberOfDoors = int.Parse(txtNumberOfDoors.Text),
                    SeatingCapacity = int.Parse(txtSeatingCapacity.Text),
                    SupplierId = int.Parse(cboSupplierId.Text),
                    Year = int.Parse(txtYear.Text),
                };
                _carService.UpdateCar(carInformation.CarId, carInformation);
                LoadData();
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
                CarInformation carInformation = new CarInformation
                {
                    CarId = int.Parse(txtCarId.Text),
                };
                _carService.DeteleCar(carInformation.CarId);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtCarDescription.Text = string.Empty;
            txtCarId.Text = string.Empty;
            txtCarName.Text = string.Empty;
            txtCarRentingPricePerDay.Text = string.Empty;
            txtFuelType.Text = string.Empty;
            cboManuFa.Text = string.Empty;
            cboSupplierId.Text = string.Empty;
            txtNumberOfDoors.Text = string.Empty;
            lvManagerCar.SelectedItem = null;
            txtSeatingCapacity.Text = string.Empty;
            txtYear.Text = string.Empty;
        }


    }
}
