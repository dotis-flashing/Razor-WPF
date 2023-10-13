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
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Entity.FUCarRentingManagementContext _context = new FUCarRentingManagementContext();
      

        public IList<BusinessObjects.Entity.RentingDetail> RentingDetail { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.RentingDetails != null)
            {
                RentingDetail = await _context.RentingDetails
                .Include(r => r.Car)
                .Include(r => r.RentingTransaction).ToListAsync();
            }
        }
    }
}
