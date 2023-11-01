using BusinessObjects.Entity;
using Repository.Generic;


namespace Repository.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer Login(string email, string password);
        Customer Profile(int customerId);
        List<Customer> GetCustomersALl();
        bool ExistEmail(string email);
        bool ExistPhone(string phone);

    }
}
