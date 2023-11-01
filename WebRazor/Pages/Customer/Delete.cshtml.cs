
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service;

namespace WebRazor.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DeleteModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [BindProperty]
        public BusinessObjects.Entity.Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var customer = _customerService.Profile(id);
                Customer = customer;
                return Page();
            }
            catch (Exception ex) { throw new Exception(ex.Message.ToString()); }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {
                _customerService.Delete(Customer.CustomerId);
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
