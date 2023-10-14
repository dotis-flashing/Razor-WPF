using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace WebRazor.Pages.RentingTransaction
{
    public class CreateModel : PageModel
    {

        private readonly IRentingTransactionService _transactionService;
        private readonly ICarService _carService;
        private readonly IRentingDetailService _detailService;

        public CreateModel(IRentingTransactionService transactionService, ICarService carService, IRentingDetailService detailService)
        {
            _transactionService = transactionService;
            _carService = carService;
            _detailService = detailService;
        }

        [BindProperty]
        public BusinessObjects.Entity.Customer Customer { get; set; } = default!;
        [BindProperty]
        public List<BusinessObjects.Entity.CarInformation> CarInformation { get; set; } = default!;
        public IActionResult OnGet()
        {
            var customerJson = HttpContext.Session.GetString("customerId");
            if (customerJson != null)
            {
                var customerId = int.Parse(customerJson); // Chuyển đổi chuỗi thành kiểu dữ liệu phù hợp nếu cần
                CarInformation= _carService.GetCarInformationAll();
                //Customer.CustomerId=customerId;
                ViewData["CustomerId"] = customerId;
                ViewData["CarId"] = new SelectList(CarInformation, "CarId", "CarId");

            }
            return Page();
        }

        public BusinessObjects.Entity.CarInformation CarInformationId { get; set; } = default!;

        [BindProperty]
        public BusinessObjects.Entity.RentingTransaction RentingTransaction { get; set; } = default!;
        [BindProperty]
        public BusinessObjects.Entity.RentingDetail RentingDetail { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            RentingTransaction = _transactionService.AddRenting(RentingTransaction);
            RentingDetail = new BusinessObjects.Entity.RentingDetail
            {
                RentingTransactionId = RentingTransaction.RentingTransationId,
                CarId= RentingDetail.CarId,
                Price= RentingDetail.Price,
                
            };
            RentingDetail = _detailService.Add(RentingDetail);  
            RentingTransaction.CustomerId = Customer.CustomerId;

            return RedirectToPage("./Index");

        }

    }
}
