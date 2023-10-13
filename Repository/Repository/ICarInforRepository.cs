using BusinessObjects.Entity;
using Repository.Generic;


namespace Repository.Repository
{
    public interface ICarInforRepository  : IGenericRepository<CarInformation>
    {
        List<CarInformation> GetAllCar();
        CarInformation GetCarByid(int id);
    }
}
