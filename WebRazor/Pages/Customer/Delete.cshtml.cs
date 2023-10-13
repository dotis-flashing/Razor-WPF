using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private readonly ICustomerService _customerService = new CustomerService();

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
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
