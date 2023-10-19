using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Infrastructure.Service;
using Infrastructure.Service.Implement;
using Microsoft.AspNetCore.Mvc;

namespace WebRazor.Pages.RentingTransaction
{
    public class IndexModel : PageModel
    {
        private readonly IRentingTransactionService _rentingTransactionService ;

        public IndexModel(IRentingTransactionService rentingTransactionService)
        {
            _rentingTransactionService = rentingTransactionService;
        }

        [BindProperty]
        public List<BusinessObjects.Entity.RentingTransaction> RentingTransaction { get; set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                var customerJson = HttpContext.Session.GetString("customerId");
                if (customerJson != null)
                {
                    var customerId = int.Parse(customerJson); // Chuyển đổi chuỗi thành kiểu dữ liệu phù hợp nếu cần
                    RentingTransaction = _rentingTransactionService.GetRentingTransactionByCustomerID(customerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
