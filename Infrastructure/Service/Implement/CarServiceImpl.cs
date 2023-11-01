using BusinessObjects.Entity;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Repository.Repository;


namespace Infrastructure.Service.Implement
{
    public class CarServiceImpl : ICarService
    {
        private readonly IUnitofWork _unitofWork;

        public CarServiceImpl(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public CarInformation AddCar(CarInformation car)
        {
            try
            {
                var addCar = _unitofWork.CarInforRepository.Add(car);
                var manu = _unitofWork.ManuFacture.GetByIdManu(addCar.ManufacturerId);
                var supplier = _unitofWork.Supplier.GetSupplierById(addCar.SupplierId);
                addCar.CarStatus = "ACTIVE";
                _unitofWork.Commit();
                return addCar;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public CarInformation DeteleCar(int carId)
        {
            var car = _unitofWork.CarInforRepository.GetCarByid(carId);
            car.CarStatus = "INACTIVE";
            _unitofWork.CarInforRepository.Update(car);
            _unitofWork.Commit();
            return car;
        }

        public CarInformation GetById(int carId)
        {
            return _unitofWork.CarInforRepository.GetCarByid(carId);
        }

        public List<CarInformation> GetCarInformationAll()
        {
            return _unitofWork.CarInforRepository.GetAllCar();
        }

        public CarInformation UpdateCar(int carId, CarInformation car)
        {
            var checkId = _unitofWork.CarInforRepository.GetCarByid(carId);
            checkId.CarId = car.CarId;
            checkId.CarName = car.CarName;
            checkId.CarRentingPricePerDay = car.CarRentingPricePerDay;
            checkId.SeatingCapacity = car.SeatingCapacity;
            checkId.CarStatus = "ACTIVE";
            checkId.CarDescription = car.CarDescription;
            checkId.FuelType = car.FuelType;
            checkId.Year = car.Year;
            checkId.NumberOfDoors = car.NumberOfDoors;
           
            _unitofWork.CarInforRepository.Update(checkId);
            _unitofWork.Commit();
            return checkId;
        }
    }
}
