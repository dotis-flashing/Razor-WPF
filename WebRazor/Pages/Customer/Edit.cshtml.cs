using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Customer
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public EditModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

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
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                return Page();
            }
        }


    }
}
