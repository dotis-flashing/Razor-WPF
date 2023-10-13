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
    public class IndexModel : PageModel
    {
        private readonly IManuFactureService _manuFactureService = new ManufactureService();

        public List<Manufacturer> Manufacturer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {

                var manu = _manuFactureService.GetManufacturersAll();
                Manufacturer = manu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
