using BusinessObjects.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Generic.GenericImp;


namespace Repository.Repository.Imp
{
    public class CarRepository : GenericRepositoryImp<CarInformation>, ICarInforRepository
    {
        public CarRepository(FUCarRentingManagementContext context) : base(context)
        {
        }

        public List<CarInformation> GetAllCar()
        {
            return _context.Set<CarInformation>().Include(c => c.Manufacturer).Include(c => c.Supplier).ToList();
        }

        public CarInformation GetCarByid(int id)
        {
            var car = _context.Set<CarInformation>().FirstOrDefault(c => c.CarId == id);
            if (car == null)
            {
                throw new Exception("Khong tim thay car Id");

            }
            return car;
        }
    }
}
