
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service;

namespace WebRazor.Pages.RentingDetail
{
    public class IndexModel : PageModel
    {
        private readonly IRentingDetailService _rentingDetailService;

        public IndexModel(IRentingDetailService rentingDetailService)
        {
            _rentingDetailService = rentingDetailService;
        }

        public List<BusinessObjects.Entity.RentingDetail> RentingDetail { get; set; } = default!;

        public async Task OnGetAsync(int id)
        {
            try
            {

                var customer = HttpContext.Session.GetString("customerId");
                if (customer != null)
                {
                    var customerId = int.Parse(customer);
                    RentingDetail = _rentingDetailService.GetListRentingByCustomerId(id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
