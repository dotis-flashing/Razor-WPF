using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.CarInfor
{
    public class EditModel : PageModel
    {
        private readonly ICarService _carService = new CarServiceImpl();
        private readonly IManuFactureService _manuFactureService = new ManufactureService();
        private readonly ISupplierService _supplierService = new SupplerService();

        [BindProperty]
        public CarInformation CarInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carinformation = _carService.GetById(id);
            var listmanu = _manuFactureService.GetManufacturersAll();
            var listsupplier = _supplierService.GetSuppliersAll();
            if (carinformation == null)
            {
                return NotFound();
            }
            CarInformation = carinformation;
            ViewData["ManufacturerId"] = new SelectList(listmanu, "ManufacturerId", "ManufacturerName");
            ViewData["SupplierId"] = new SelectList(listsupplier, "SupplierId", "SupplierName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                CarInformation = _carService.UpdateCar(CarInformation.CarId, CarInformation);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
