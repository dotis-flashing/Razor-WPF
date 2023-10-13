using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _customerService = new CustomerService();

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessObjects.Entity.Customer Customer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var customer =  _customerService.Register(Customer);
                Customer = customer;
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
