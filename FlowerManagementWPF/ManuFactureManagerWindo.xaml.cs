using BusinessObjects.Entity;
using Infrastructure.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for ManuFactureManagerWindo.xaml
    /// </summary>
    public partial class ManuFactureManagerWindo : Window
    {
        private readonly IManuFactureService _manuFactureService;

        public ManuFactureManagerWindo(IManuFactureService manuFactureService)
        {
            InitializeComponent();
            _manuFactureService = manuFactureService;
            LoadData();
        }

        private void LoadData()
        {
            var load = _manuFactureService.GetManufacturersAll();
            lvManagerManu.ItemsSource = load;
        }
        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerName = txtManufacturerName.Text,
                    ManufacturerCountry = txtManufacturerCountry.Text,
                    Description = txtDescription.Text,
                };
                _manuFactureService.AddManu(manufacturer);
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
                Manufacturer manufacturer = new Manufacturer
                {
                    ManufacturerId = int.Parse(txtManufacturerId.Text),
                    ManufacturerName = txtManufacturerName.Text,
                    ManufacturerCountry = txtManufacturerCountry.Text,
                    Description = txtDescription.Text,
                };
                _manuFactureService.UpdateManu(manufacturer.ManufacturerId, manufacturer);
                LoadData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtManufacturerId.Text = string.Empty;
            txtManufacturerName.Text = string.Empty;
            txtManufacturerCountry.Text = string.Empty;
            txtDescription.Text = string.Empty;
            lvManagerManu.SelectedItem = null;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
