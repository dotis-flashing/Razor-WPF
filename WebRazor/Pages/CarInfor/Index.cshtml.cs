using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.CarInfor
{
    public class IndexModel : PageModel
    {
        private readonly ICarService _carService = new CarServiceImpl();

        public List<CarInformation> CarInformation { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                CarInformation = _carService.GetCarInformationAll();
                Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
