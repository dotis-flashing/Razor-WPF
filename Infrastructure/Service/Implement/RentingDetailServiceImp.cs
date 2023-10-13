

using BusinessObjects.Entity;
using Infrastructure.IUnitOfWork;
using Infrastructure.IUnitOfWork.UnitOfWorkImp;

namespace Infrastructure.Service.Implement
{
    public class RentingDetailServiceImp : IRentingDetailService
    {
        private readonly IUnitofWork _unitOfWork;

        public RentingDetailServiceImp()
        {
            _unitOfWork = new UnitofWork(new FUCarRentingManagementContext());
        }

        public RentingDetail Add(RentingDetail renting)
        {
            var ren = _unitOfWork.RentingDetailRepository.Add(renting);
            ren.CarId = renting.CarId;
            ren.RentingDetailStatus = "ACTIVE";
            _unitOfWork.Commit();
            return ren;
        }

        public RentingDetail Detele(int id)
        {
            var ren = _unitOfWork.RentingDetailRepository.GetById(id);
            ren.RentingDetailStatus = "INACTIVE";
            _unitOfWork.RentingDetailRepository.Update(ren);
            _unitOfWork.Commit();
            return ren;
        }

        public List<RentingDetail> GetALl()
        {
            return _unitOfWork.RentingDetailRepository.GetRentingDetailsAll();
        }

        public RentingDetail Update(int id, RentingDetail renting)
        {
            var ren = _unitOfWork.RentingDetailRepository.GetById(id);
            ren.RentingDetailStatus = "ACTIVE";
            _unitOfWork.RentingDetailRepository.Update(renting);
            _unitOfWork.Commit();
            return ren;
        }
    }
}
