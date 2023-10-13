
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using Repository.Repository.Imp;
using System.Windows;

namespace FlowerManagementWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            serviceProvider = service.BuildServiceProvider();
        }

        

        private void ConfigureServices(ServiceCollection service)
        {
            // SERVICE
            service.AddScoped<ICustomerService, CustomerService>();
            service.AddScoped<ISupplierService, SupplerService>();
            service.AddScoped<IManuFactureService, ManufactureService>();
            service.AddScoped<IRentingTransactionService, RentingTransactionService>();
            service.AddScoped<ICarService, CarServiceImpl>();


            // REPOSITORY
            service.AddTransient<ICarInforRepository, CarRepository>();
            service.AddTransient<ICustomerRepository, CustomerRepository>();
            service.AddTransient<IRentingTransactionRepository, RentingTransactionRepository>();
            service.AddTransient<IManuFactureRepository, ManuFactureRepository>();
            service.AddTransient<ISupplier, SupplierRepository>();
            service.AddSingleton<MainWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
