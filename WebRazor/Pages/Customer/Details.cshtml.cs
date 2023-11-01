using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebRazor.Pages.Customer
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public DetailsModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public BusinessObjects.Entity.Customer Customer { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var customer = _customerService.Profile(id);
                Customer = customer;
                return Page();
            }catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
              return  Page();
            }

        }
    }
}
