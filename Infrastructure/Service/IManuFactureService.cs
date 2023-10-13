using BusinessObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface IManuFactureService
    {
        List<Manufacturer> GetManufacturersAll();
        Manufacturer AddManu(Manufacturer manufacturer);
        Manufacturer UpdateManu(int id,Manufacturer manufacturer);
        Task<Manufacturer> GetById(int id);
        Task<Manufacturer> Delete(int id);
    }
}
