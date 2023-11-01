using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.Manufacture
{
    public class EditModel : PageModel
    {
        private readonly IManuFactureService _manuFactureService;

        public EditModel(IManuFactureService manuFactureService)
        {
            _manuFactureService = manuFactureService;
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var manu = await _manuFactureService.GetById(id);
            Manufacturer = manu;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var manu = _manuFactureService.UpdateManu(Manufacturer.ManufacturerId, Manufacturer);
                Manufacturer = manu;
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

    }
}
