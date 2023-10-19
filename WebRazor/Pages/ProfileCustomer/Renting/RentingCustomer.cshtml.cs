using Infrastructure.Service.Implement;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebRazor.Pages.ProfileCustomer.Renting
{
    public class RentingCustomerModel : PageModel
    {
        private readonly IRentingTransactionService _rentingTransactionService;

        public RentingCustomerModel(IRentingTransactionService rentingTransactionService)
        {
            _rentingTransactionService = rentingTransactionService;
        }

        public List<BusinessObjects.Entity.RentingTransaction> RentingTransaction { get; set; } = default!;

        public async Task OnGetAsync(int customerId)
        {
            try
            {
                RentingTransaction = _rentingTransactionService.GetRentingTransactionByCustomerID(customerId);
                Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
