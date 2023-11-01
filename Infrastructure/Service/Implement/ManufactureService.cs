using BusinessObjects.Entity;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;
using Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class ManufactureService : IManuFactureService
    {
        private readonly IUnitofWork _unitofWork;

        public ManufactureService(IUnitofWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public Manufacturer AddManu(Manufacturer manufacturer)
        {
            var addManu = _unitofWork.ManuFacture.Add(manufacturer);
            addManu.ManufacturerStatus = "ACTIVE";
            _unitofWork.Commit();
            return addManu;
        }

        public async Task<Manufacturer> Delete(int id)
        {
            var addManu = _unitofWork.ManuFacture.GetByIdManu(id);
            addManu.ManufacturerStatus = "INACTIVE";
            _unitofWork.CommitAsync();
            return addManu;

        }

        public async Task<Manufacturer> GetById(int id)
        {
            var manuId = _unitofWork.ManuFacture.GetByIdManu(id);
            return manuId;
        }

        public List<Manufacturer> GetManufacturersAll()
        {
            return _unitofWork.ManuFacture.GetAll();
        }

        public Manufacturer UpdateManu(int id, Manufacturer manufacturer)
        {
            var manu = _unitofWork.ManuFacture.GetByIdManu(id);
            if (manu != null)
            {
                manu.ManufacturerId = manufacturer.ManufacturerId;
                manu.ManufacturerName = manufacturer.ManufacturerName;
                manu.ManufacturerCountry = manufacturer.ManufacturerCountry;
                manu.ManufacturerStatus = "ACTIVE";
                manu.Description = manufacturer.Description;
                _unitofWork.ManuFacture.Update(manu);
                _unitofWork.Commit();
                return manu;
            }
            return manu;
        }

    }
}
