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

namespace WebRazor.Pages.RentingTransaction
{
    public class DeleteModel : PageModel
    {
        private readonly IRentingTransactionService _transactionService = new RentingTransactionService();
        [BindProperty]
        public BusinessObjects.Entity.RentingTransaction RentingTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                RentingTransaction = _transactionService.GetById(id);
                return Page();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            try
            {
                RentingTransaction =  _transactionService.DeleteRenting(id);
                return RedirectToPage("./Index");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
