using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Generic.GenericImp;


namespace Repository.Repository.Imp
{
    public class SupplierRepository : GenericRepositoryImp<Supplier>, ISupplier
    {
        public SupplierRepository(FUCarRentingManagementContext context) : base(context)
        {
        }

        public Supplier GetSupplierById(int id)
        {
            var supplierId = _context.Set<Supplier>().Include(c=>c.CarInformations).FirstOrDefault(c => c.SupplierId == id);
            if (supplierId == null)
            {
                throw new Exception("Khong tim thay Supplier Id");
            }
            return supplierId;
        }

        public List<Supplier> GetSuppliers()
        {
            return _context.Set<Supplier>().Include(c=>c.CarInformations).ToList();
        }
    }
}
