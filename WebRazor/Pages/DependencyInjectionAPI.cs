using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Infrastructure.IUnitOfWork;
using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Repository.Repository.Imp;
using Repository.Repository;
using Repository.Generic;
using Repository.Generic.GenericImp;

namespace WebRazor.Pages
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddDJ(this IServiceCollection services)
        {
            services.AddRazorPages();

            // SERVICE
            //services.AddTransient<IUnitofWork, UnitofWork>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISupplierService, SupplerService>();
            services.AddScoped<IManuFactureService, ManufactureService>();
            services.AddScoped<IRentingTransactionService, RentingTransactionService>();
            services.AddScoped<ICarService, CarServiceImpl>();
            services.AddScoped<IRentingDetailService, RentingDetailServiceImp>();

            //// REPOSITORY
            //services.AddScoped<ICarInforRepository, CarRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IRentingTransactionRepository, RentingTransactionRepository>();
            //services.AddScoped<IManuFactureRepository, ManuFactureRepository>();
            //services.AddScoped<ISupplier, SupplierRepository>();

            return services;
        }
    }
}
