using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service;

namespace WebRazor.Pages.Suppiler
{
    public class EditModel : PageModel
    {
        private readonly ISupplierService _supplierService;

        public EditModel(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        [BindProperty]
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
                Supplier = supplier;
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                Supplier = _supplierService.UpdateSupplier(Supplier.SupplierId, Supplier);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
