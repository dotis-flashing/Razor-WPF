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
    public class SupplerService : ISupplierService
    {
        private readonly IUnitofWork _unitofWork;

        public SupplerService()
        {
            _unitofWork = new UnitofWork(new FUCarRentingManagementContext());
        }

        public Supplier AddSupplier(Supplier supplier)
        {
            var addSupplier = _unitofWork.Supplier.Add(supplier);
            addSupplier.SupplierStatus = "ACTIVE";
            _unitofWork.Commit();
            return addSupplier;
        }

        public Supplier Delete(int supplierId)
        {
            var id = _unitofWork.Supplier.GetSupplierById(supplierId);
            id.SupplierStatus = "INACTIVE";
            _unitofWork.Supplier.Update(id);
            _unitofWork.Commit();
            return id;
        }

        public Supplier GetById(int supplierId)
        {
            return _unitofWork.Supplier.GetSupplierById(supplierId);
        }

        public List<Supplier> GetSuppliersAll()
        {
            return _unitofWork.Supplier.GetSuppliers();
        }

        public Supplier UpdateSupplier(int supplierId, Supplier supplier)
        {
            var id = _unitofWork.Supplier.GetSupplierById(supplierId);
            id.SupplierName = supplier.SupplierName;
            id.SupplierAddress = supplier.SupplierAddress;
            id.SupplierStatus = "ACTIVE";
            id.SupplierDescription = supplier.SupplierDescription;
            _unitofWork.Supplier.Update(id);
            _unitofWork.Commit();
            return id;
        }
    }
}
