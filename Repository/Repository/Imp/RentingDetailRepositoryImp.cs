using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Generic.GenericImp;

namespace Repository.Repository.Imp
{
    public class RentingDetailRepositoryImp : GenericRepositoryImp<RentingDetail>, IRentingDetailRepository
    {
        public RentingDetailRepositoryImp(FUCarRentingManagementContext context) : base(context)
        {
        }

        public RentingDetail GetById(int id)
        {
            var rentingId = _context.Set<RentingDetail>().FirstOrDefault(c => c.RentingTransactionId == id);
            if (rentingId == null)
            {
                throw new Exception("Khong tim thay rentingId");
            }
            return rentingId;
        }

        public List<RentingDetail> GetRentingDetailsAll()
        {
            return _context.Set<RentingDetail>().Include(c => c.RentingTransaction).Include(c => c.Car).ToList();
        }
    }
}
