

using BusinessObjects.Entity;

namespace Infrastructure.Service
{
    public interface IRentingDetailService
    {
        RentingDetail Add(RentingDetail renting);
        List<RentingDetail> GetListRentingByCustomerId(int id);
        RentingDetail GetListRentingBy(int id);
        RentingDetail Update(int id, RentingDetail renting);
        RentingDetail Detele(int id);
        List<RentingDetail> GetALl();

    }
}
