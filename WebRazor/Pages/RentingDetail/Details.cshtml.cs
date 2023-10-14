using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service;

namespace WebRazor.Pages.RentingDetail
{
    public class DetailsModel : PageModel
    {

        private readonly IRentingDetailService _rentingDetailService;

        public DetailsModel(IRentingDetailService rentingDetailService)
        {
            _rentingDetailService = rentingDetailService;
        }

        [BindProperty]
        public BusinessObjects.Entity.RentingDetail RentingDetail { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            var rentingdetail = _rentingDetailService.GetListRentingBy(id);
            if (rentingdetail == null)
            {
                return NotFound();
            }
            else
            {
                RentingDetail = rentingdetail;
            }
            return Page();
        }
    }
}
