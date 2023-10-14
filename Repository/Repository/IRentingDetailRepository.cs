using BusinessObjects.Entity;
using Repository.Generic;


namespace Repository.Repository
{
    public interface IRentingDetailRepository : IGenericRepository<RentingDetail>
    {
        List<RentingDetail> GetRentingDetailsAll();
        RentingDetail GetById(int id);
        List<RentingDetail> GetByIds(int id);
    }
}
