using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Suppiler
{
    public class DetailsModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public DetailsModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public Supplier Supplier { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {

                if (id == null)
                {
                    return NotFound();
                }

                var supplier = _supplierService.GetById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                else
                {
                    Supplier = supplier;
                }
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
