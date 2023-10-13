using BusinessObjects.Entity;
using Repository.Generic;


namespace Repository.Repository
{
    public interface IRentingTransactionRepository : IGenericRepository<RentingTransaction>
    {
        List<RentingTransaction> GetRentingTransactionByCustomerID(int customerID);
        RentingTransaction GetById(int renting);
    }
}
