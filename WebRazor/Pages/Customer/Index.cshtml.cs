using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebRazor.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _customerService = new CustomerService();

        public List<BusinessObjects.Entity.Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                var customers = _customerService.GetCustomerAll();
                Customer = customers;
                Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
