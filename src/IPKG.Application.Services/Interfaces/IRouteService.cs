using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IPKG.Application.Services.Dto;
using IPKG.Domain;

namespace IPKG.Application.Services.Interfaces
{
    public interface IRouteService
    {
        Task<IEnumerable<Route>> GetAllRoutes();
        Task<Route> GetRouteByReference(Guid reference);
        Task<Route> InsertUpdateRoute(RouteDto route);

    }
}
