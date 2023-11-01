using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.Manufacture
{
    public class CreateModel : PageModel
    {
        private readonly IManuFactureService _manuFactureService;

        public CreateModel(IManuFactureService manuFactureService)
        {
            _manuFactureService = manuFactureService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Manufacturer Manufacturer { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var manu = _manuFactureService.AddManu(Manufacturer);
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
