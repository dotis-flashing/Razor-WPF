using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.Manufacture
{
    public class DetailsModel : PageModel
    {
        private readonly IManuFactureService _manuFactureService;

        public DetailsModel(IManuFactureService manuFactureService)
        {
            _manuFactureService = manuFactureService;
        }

        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var manu = await _manuFactureService.GetById(id);
                Manufacturer = manu;
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
