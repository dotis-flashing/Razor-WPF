using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Generic.GenericImp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Imp
{
    public class CustomerRepository : GenericRepositoryImp<Customer>, ICustomerRepository
    {
        public CustomerRepository(FUCarRentingManagementContext context) : base(context)
        {
        }

        public bool ExistEmail(string email)
        {
            var check = _context.Set<Customer>().FirstOrDefault(c => c.Email == email);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public bool ExistPhone(string phone)
        {
            var check = _context.Set<Customer>().FirstOrDefault(c => c.Telephone == phone);
            if (check != null)
            {
                return true;
            }
            return false;
        }

        public List<Customer> GetCustomersALl()
        {
            return _context.Set<Customer>().ToList();
        }
        public Customer Login(string email, string password)
        {

            var customer = _context.Set<Customer>().FirstOrDefault(c => c.Email == email && c.Password == password);
            if (customer == null)
            {
                throw new Exception("khong dang nhap duoc");
            }

            return customer;
        }

        public Customer Profile(int customerId)
        {
            var customer = _context.Set<Customer>().Include(c => c.RentingTransactions).FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                throw new Exception("Khong tim thay Id");

            }
            return customer;
        }


    }
}
