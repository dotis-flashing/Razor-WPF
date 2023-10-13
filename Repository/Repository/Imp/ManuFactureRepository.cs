using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Generic.GenericImp;


namespace Repository.Repository.Imp
{
    public class ManuFactureRepository : GenericRepositoryImp<Manufacturer>, IManuFactureRepository
    {
        public ManuFactureRepository(FUCarRentingManagementContext context) : base(context)
        {
        }

        public List<Manufacturer> GetAll()
        {
            return _context.Set<Manufacturer>().Include(c=>c.CarInformations).ToList();
        }

        public Manufacturer GetByIdManu(int id)
        {
            var manu = _context.Set<Manufacturer>().FirstOrDefault(c => c.ManufacturerId == id);
            if (manu == null)
            {
                throw new Exception("Khong tim thay Manu Id");
            }
            return manu;
        }
    }
}
