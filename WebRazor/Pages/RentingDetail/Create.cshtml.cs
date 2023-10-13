using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Entity;

namespace WebRazor.Pages.RentingDetail
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Entity.FUCarRentingManagementContext _context = new FUCarRentingManagementContext();


        public IActionResult OnGet()
        {
        ViewData["CarId"] = new SelectList(_context.CarInformations, "CarId", "CarName");
        ViewData["RentingTransactionId"] = new SelectList(_context.RentingTransactions, "RentingTransationId", "RentingStatus");
            return Page();
        }

        [BindProperty]
        public BusinessObjects.Entity.RentingDetail RentingDetail { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RentingDetails == null || RentingDetail == null)
            {
                return Page();
            }

            _context.RentingDetails.Add(RentingDetail);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
