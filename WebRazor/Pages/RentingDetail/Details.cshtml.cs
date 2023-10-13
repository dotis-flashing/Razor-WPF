using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;

namespace WebRazor.Pages.RentingDetail
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Entity.FUCarRentingManagementContext _context = new FUCarRentingManagementContext();



        public BusinessObjects.Entity.RentingDetail RentingDetail { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RentingDetails == null)
            {
                return NotFound();
            }

            var rentingdetail = await _context.RentingDetails.FirstOrDefaultAsync(m => m.RentingTransactionId == id);
            if (rentingdetail == null)
            {
                return NotFound();
            }
            else 
            {
                RentingDetail = rentingdetail;
            }
            return Page();
        }
    }
}
