using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.CarInfor
{
    public class CreateModel : PageModel
    {
        private readonly ICarService _carService;
        private readonly IManuFactureService _manuFactureService;
        private readonly ISupplierService _supplierService;

        public CreateModel(ICarService carService, IManuFactureService manuFactureService, ISupplierService supplierService)
        {
            _carService = carService;
            _manuFactureService = manuFactureService;
            _supplierService = supplierService;
        }

        [BindProperty]
        public CarInformation CarInformation { get; set; } = default!;
        [BindProperty]
        public List<Manufacturer> Manufacturer { get; set; } = default!;
        [BindProperty]
        public List<Supplier> Supplier { get; set; } = default!;
        public IActionResult OnGet()
        {
            Manufacturer = _manuFactureService.GetManufacturersAll();
            Supplier = _supplierService.GetSuppliersAll();
            ViewData["ManufacturerId"] = new SelectList(Manufacturer, "ManufacturerId", "ManufacturerName");
            ViewData["SupplierId"] = new SelectList(Supplier, "SupplierId", "SupplierName");

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var carInformation = _carService.AddCar(CarInformation);
                CarInformation = carInformation;
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
