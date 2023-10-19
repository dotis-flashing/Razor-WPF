using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Suppiler
{
    public class CreateModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public CreateModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Supplier Supplier { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Supplier = _supplierService.AddSupplier(Supplier);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
