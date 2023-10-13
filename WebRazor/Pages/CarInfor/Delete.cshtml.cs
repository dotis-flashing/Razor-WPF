using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service.Implement;
using Infrastructure.Service;

namespace WebRazor.Pages.CarInfor
{
    public class DeleteModel : PageModel
    {
        private readonly ICarService _carService = new CarServiceImpl();


        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int id)
        {
            try
            {

                _carService.DeteleCar(id);
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
