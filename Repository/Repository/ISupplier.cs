using BusinessObjects.Entity;
using Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public interface ISupplier : IGenericRepository<Supplier>
    {
        List<Supplier> GetSuppliers();
        Supplier GetSupplierById(int id);
    }
}
