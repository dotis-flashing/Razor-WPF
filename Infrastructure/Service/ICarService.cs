using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface ICarService
    {
        List<CarInformation> GetCarInformationAll();
        CarInformation DeteleCar(int carId);
        CarInformation GetById(int carId);
        CarInformation AddCar(CarInformation car);
        CarInformation UpdateCar(int carId,CarInformation car);
    }
}
