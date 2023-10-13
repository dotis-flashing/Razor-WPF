using Repository.Repository;

namespace Infrastructure.IUnitOfWork
{
    public interface IUnitofWork
    {
        ICustomerRepository Customer { get; }
        IRentingTransactionRepository RentingTransaction { get; }
        ISupplier Supplier { get; }
        IManuFactureRepository ManuFacture { get; }
        ICarInforRepository CarInforRepository { get; }
        IRentingDetailRepository RentingDetailRepository { get; }
        void Commit();
        void CommitAsync();
    }
}
