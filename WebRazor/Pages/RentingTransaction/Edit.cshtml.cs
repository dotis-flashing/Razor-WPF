using Infrastructure.Service;
using Infrastructure.Service.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace WebRazor.Pages.RentingTransaction
{
    public class EditModel : PageModel
    {
        private readonly IRentingTransactionService _transactionService ;

        public EditModel(IRentingTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [BindProperty]
        public BusinessObjects.Entity.RentingTransaction RentingTransaction { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var customerJson = HttpContext.Session.GetString("customerId");
            RentingTransaction =_transactionService.GetById(id);
            if (customerJson != null)
            {
                var customerId = int.Parse(customerJson); // Chuyển đổi chuỗi thành kiểu dữ liệu phù hợp nếu cần
                RentingTransaction.CustomerId = customerId;
                ViewData["CustomerId"] = customerId;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
                RentingTransaction = _transactionService.UpdateRenting(RentingTransaction.RentingTransationId, RentingTransaction);
                return RedirectToPage("./Index");
        }

    }
}
