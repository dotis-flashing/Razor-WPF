using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IRentingTransactionService
    {
        List<RentingTransaction> GetRentingTransactionByCustomerID(int customerID);
        RentingTransaction AddRenting(RentingTransaction rentingTransaction);
        RentingTransaction DeleteRenting(int rentingTransactionId);
        RentingTransaction UpdateRenting(int rentingTrId ,RentingTransaction rentingTransaction);
        RentingTransaction GetById(int rentingTransactionId);

    }
}
