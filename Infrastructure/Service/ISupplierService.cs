using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ISupplierService
    {
        List<Supplier> GetSuppliersAll();
        Supplier AddSupplier(Supplier supplier);
        Supplier UpdateSupplier(int supplierId,Supplier supplier);
        Supplier GetById(int supplierId);
        Supplier Delete(int supplierId);
    }
}
