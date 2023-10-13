using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazor.Pages.ProfileCustomer.Customer
{
    public class ProfileCustomerModel : PageModel
    {
        private readonly ICustomerService _customerService = new CustomerService();
        [BindProperty]
        public BusinessObjects.Entity.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customer = _customerService.Profile(id);
            Customer = customer;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Customer = _customerService.updateCustomer(Customer.CustomerId, Customer);
                //Customer = customer;
                return RedirectToPage("/uirole");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
