using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPKG.Application.Services.Repositories;
using IPKG.Domain;

namespace IPKG.Infrastructure.Ef.Repositories
{
    internal class RouteRepository : IRouteRepository
    {
        private readonly DatabaseContext _context;
        public IUnitOfWork UnitOfWork { get; }
        public RouteRepository(DatabaseContext context)
        {
            _context = context;
            UnitOfWork = context;
        }

        public async Task<IEnumerable<Route>> GetAllRoutes()
        {
            return await Task.FromResult(_context.Routes);
        }

        public Task<Route> AddRoute(Route route)
        {
            _context.Routes.Add(route);
            return Task.FromResult(route);
        }

        public async Task<Route> GetByReference(Guid reference)
        {
            return await Task.FromResult(_context.Routes.FirstOrDefault(x => x.Reference == reference));
        }
    }
}
