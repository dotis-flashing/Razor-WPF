using BusinessObjects.Entity;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Service.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitofWork _unitOfWork;

        public CustomerService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Customer CustomerLogin(string email, string password)
        {
            var customer = _unitOfWork.Customer.Login(email, password);
            return customer;
        }

        public Customer Profile(int customerId)
        {
            return _unitOfWork.Customer.Profile(customerId);
        }
        public bool Login(string email, string password)
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var adminJson = config["AdminConectString:Admin"];
            var passwordJson = config["AdminConectString:Password"];

            if (adminJson.Equals(email) && !passwordJson.Equals(password))
            {
                throw new Exception("Sai password");
            }
            else if (adminJson.Equals(email) && passwordJson.Equals(password))
            {
                return true;
            }
            return false;
        }

        public Customer updateCustomer(int customerId, Customer customer)
        {
            // 
            var findCustomerId = _unitOfWork.Customer.Profile(customerId);
            if (findCustomerId != null)
            {
                findCustomerId.CustomerId = customer.CustomerId;
                findCustomerId.CustomerName = customer.CustomerName;
                findCustomerId.Email = customer.Email;
                var checkemail = _unitOfWork.Customer.ExistEmail(findCustomerId.Email);
                if (checkemail == true)
                {
                    throw new Exception("exist email");
                }
                findCustomerId.Password = customer.Password;
                findCustomerId.Telephone = customer.Telephone;
                var checkphone = _unitOfWork.Customer.ExistPhone(customer.Telephone);
                if (checkphone == true)
                {
                    throw new Exception("exist phone");
                }
                findCustomerId.CustomerStatus = "ACTIVE";
                findCustomerId.CustomerBirthday = customer.CustomerBirthday;
                var customerUpdate = _unitOfWork.Customer.Update(findCustomerId);
                _unitOfWork.Commit();
                return customerUpdate;
            }
            return findCustomerId;
        }

        public Customer Register(Customer customer)
        {
            customer.Email.ToLower();
            var addCustomer = _unitOfWork.Customer.Add(customer);
            if (addCustomer.Email.Equals("admin".ToLower()))
            {
                throw new Exception("Email nay da co roi, khong duoc add nua");
            }
            var checkemail = _unitOfWork.Customer.ExistEmail(addCustomer.Email);
            if (checkemail == true)
            {
                throw new Exception("exist email");
            }
            var checkphone = _unitOfWork.Customer.ExistPhone(addCustomer.Telephone);
            if (checkphone == true)
            {
                throw new Exception("exist phone");
            }
            addCustomer.CustomerStatus = "ACTIVE";
            _unitOfWork.Commit();

            return addCustomer;

        }

        public List<Customer> GetCustomerAll()
        {
            return _unitOfWork.Customer.GetCustomersALl();
        }

        public void Delete(int id)
        {
            var customer = _unitOfWork.Customer.Profile(id);
            customer.CustomerStatus = "INACTIVE";
            _unitOfWork.Customer.Update(customer);
            _unitOfWork.Commit();
        }
    }
}
