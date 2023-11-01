using BusinessObjects.Entity;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;

namespace Infrastructure.Service.Implement
{
    public class RentingTransactionService : IRentingTransactionService
    {
        private readonly IUnitofWork _unitOfWork;

        public RentingTransactionService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RentingTransaction AddRenting(RentingTransaction rentingTransaction)
        {
            var addRenting = _unitOfWork.RentingTransaction.Add(rentingTransaction);
            if (addRenting == null)
            {
                throw new Exception("ERRROR");
            }
            addRenting.RentingStatus = "ACTIVE";
            _unitOfWork.Commit();
            return addRenting;
        }

        public RentingTransaction DeleteRenting(int rentingTransactionId)
        {
            var renting = _unitOfWork.RentingTransaction.GetById(rentingTransactionId);
            renting.RentingStatus = "INACTIVE";
            _unitOfWork.RentingTransaction.Update(renting);
            _unitOfWork.Commit();
            return renting;
        }

        public RentingTransaction GetById(int rentingTransactionId)
        {
            return _unitOfWork.RentingTransaction.GetById(rentingTransactionId);
        }

        public List<RentingTransaction> GetRentingTransactionByCustomerID(int customerID)
        {
            return _unitOfWork.RentingTransaction.GetRentingTransactionByCustomerID(customerID);
        }

        public RentingTransaction UpdateRenting(int rentingTrId, RentingTransaction rentingTransaction)
        {
            var renting = _unitOfWork.RentingTransaction.GetById(rentingTrId);
            if (rentingTransaction != null)
            {
                renting.RentingDate = rentingTransaction.RentingDate;
                renting.TotalPrice = rentingTransaction.TotalPrice;
                renting.RentingStatus = "ACTIVE";
                renting.CustomerId = rentingTransaction.CustomerId;
                _unitOfWork.RentingTransaction.Update(renting);
                _unitOfWork.Commit();
            }
            return renting;
        }
    }
}
