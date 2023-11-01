using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Repository.Repository.Imp;
using Repository.Repository;
using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebRazor
{
    public static class DependencyInjectionAPI
    {
        private static string GetConnectionString(IConfiguration configuration)
        {
            return configuration.GetConnectionString("DatabaseConnection");
        }
        public static IServiceCollection AddDJ(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FUCarRentingManagementContext>(options =>
            {
                options.UseSqlServer(GetConnectionString(configuration));
            });
            //// REPOSITORY

            services.AddTransient<ICarInforRepository, CarRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IRentingTransactionRepository, RentingTransactionRepository>();
            services.AddTransient<IManuFactureRepository, ManuFactureRepository>();
            services.AddTransient<ISupplier, SupplierRepository>();

            services.AddRazorPages();
            services.AddSignalR();

            // SERVICE
            services.AddTransient<IUnitofWork, UnitofWork>();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ISupplierService, SupplerService>();
            services.AddTransient<IManuFactureService, ManufactureService>();
            services.AddTransient<IRentingTransactionService, RentingTransactionService>();
            services.AddTransient<ICarService, CarServiceImpl>();
            services.AddTransient<IRentingDetailService, RentingDetailServiceImp>();
           


            return services;
        }
    }
}
