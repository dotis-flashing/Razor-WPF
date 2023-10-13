

using BusinessObjects.Entity;

namespace Infrastructure.Service
{
    public interface IRentingDetailService
    {
        RentingDetail Add(RentingDetail renting);
        RentingDetail Update(int id,RentingDetail renting);
        RentingDetail Detele(int id);
        List<RentingDetail> GetALl();

    }
}
