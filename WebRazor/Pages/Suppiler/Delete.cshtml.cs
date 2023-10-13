using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Suppiler
{
    public class DeleteModel : PageModel
    {
        private readonly ISupplierService _supplierService = new SupplerService();


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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {

                if (id == null)
                {
                    return NotFound();
                }
                var supplier = _supplierService.Delete(id);
                Supplier = supplier;
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
