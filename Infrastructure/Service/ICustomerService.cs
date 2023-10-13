using BusinessObjects.Entity;


namespace Infrastructure.Service
{
    public interface ICustomerService
    {
        Customer updateCustomer(int customerId, Customer customer);
        //Customer Login(string email, string password);
        Customer Profile(int customerId);
        List<Customer> GetCustomerAll();
        bool Login(string email, string password);
        Customer CustomerLogin(string email, string password);
        Customer Register(Customer customer);
        void Delete(int id);
    }
}
