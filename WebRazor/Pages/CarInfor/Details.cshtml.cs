using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.CarInfor
{
    public class DetailsModel : PageModel
    {
        private readonly ICarService _carService = new CarServiceImpl();


        public CarInformation CarInformation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {

                if (id == null)
                {
                    return NotFound();
                }

                var carinformation = _carService.GetById(id);
                if (carinformation == null)
                {
                    return NotFound();
                }
                else
                {
                    CarInformation = carinformation;
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
