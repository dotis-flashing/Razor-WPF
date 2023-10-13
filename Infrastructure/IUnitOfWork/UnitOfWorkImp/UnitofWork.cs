using BusinessObjects.Entity;
using Repository.Repository;
using Repository.Repository.Imp;

namespace Infrastructure.IUnitOfWork.UnitOfWorkImp
{
    public class UnitofWork : IUnitofWork
    {
        private readonly FUCarRentingManagementContext _context;

        private readonly ICustomerRepository _customerRepository;
        private readonly IRentingTransactionRepository _transactionRepository;
        private readonly ISupplier _supplier;
        private readonly IManuFactureRepository _manuFactureRepository;
        private readonly ICarInforRepository _carInforRepository;
        private readonly IRentingDetailRepository _rentingDetailRepository;
        public UnitofWork(FUCarRentingManagementContext context)
        {
            _context = context;
            _customerRepository = new CustomerRepository(context);
            _transactionRepository = new RentingTransactionRepository(context);
            _supplier = new SupplierRepository(context);
            _manuFactureRepository = new ManuFactureRepository(context);
            _carInforRepository = new CarRepository(context);
            _rentingDetailRepository= new RentingDetailRepositoryImp(context);
        }

        public ICustomerRepository Customer => _customerRepository;

        public IRentingTransactionRepository RentingTransaction => _transactionRepository;

        public ISupplier Supplier => _supplier;

        public IManuFactureRepository ManuFacture => _manuFactureRepository;

        public ICarInforRepository CarInforRepository => _carInforRepository;

        public IRentingDetailRepository RentingDetailRepository => _rentingDetailRepository;
        public void Commit()
                       => _context.SaveChanges();

        public void CommitAsync()
                              => _context.SaveChangesAsync();

    }
}
