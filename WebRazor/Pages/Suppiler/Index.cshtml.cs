using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Entity;
using Infrastructure.Service;
using Infrastructure.Service.Implement;

namespace WebRazor.Pages.Suppiler
{
    public class IndexModel : PageModel
    {
        private readonly ISupplierService _supplierService = new SupplerService();

        public List<Supplier> Supplier { get;set; } = default!;

        public async Task OnGetAsync()
        {
            try
            {
                Supplier = _supplierService.GetSuppliersAll();
                Page();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
