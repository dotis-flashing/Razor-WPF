using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
        //[EmailAddress]
        [Required]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }


        private readonly ICustomerService _customerService;

        public LoginPageModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
                {
                    var admin = _customerService.Login(Email, Password);
                    if (admin == true)
                    {
                        HttpContext.Session.SetString("role", "admin");
                        //HttpContext.Session.SetInt32("CustomerId", admin./*CustomerId*/);
                        return Redirect("/uirole");

                    }
                    else if (admin == false)
                    {
                        var customer = _customerService.CustomerLogin(Email, Password);
                        HttpContext.Session.SetString("role", "customer");
                        HttpContext.Session.SetString("customerId", customer.CustomerId.ToString());

                        return Redirect("/uirole");
                    }
                    return Page();

                }
            }
            catch (Exception ex)
            {
                ViewData["Message"] = ex.Message.ToString();
                ViewData["Email"] = Email;
                return Page();

            }
        }
    }
}


