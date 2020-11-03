using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IPKG.Domain;

namespace IPKG.Application.Services.Interfaces
{
    public interface IParkingService
    {
        IEnumerable<Parking> GetAllCarParks();
    }
}
