using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IPKG.Domain;

namespace IPKG.Application.Services.Repositories
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetAllRoutes();
        Task<Route> AddRoute(Route route);
        Task<Route> GetByReference(Guid reference);
        IUnitOfWork UnitOfWork { get; }
    }
}
