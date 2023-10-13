using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Generic.GenericImp;


namespace Repository.Repository.Imp
{
    public class RentingTransactionRepository : GenericRepositoryImp<RentingTransaction>, IRentingTransactionRepository
    {
        public RentingTransactionRepository(FUCarRentingManagementContext context) : base(context)
        {
        }

        public RentingTransaction GetById(int renting)
        {
            var rentingTr= _context.Set<RentingTransaction>().FirstOrDefault(r => r.RentingTransationId == renting);
            if(rentingTr == null) {
                throw new Exception("Khong tim thay Renting ID");
            }
            return rentingTr;
        }

        public List<RentingTransaction> GetRentingTransactionByCustomerID(int customerID)
        {
            var renting = _context.Set<RentingTransaction>().Include(c => c.Customer).Include(c => c.RentingDetails).Where(c => c.CustomerId == customerID).ToList();
            return renting;
        }
    }
}
