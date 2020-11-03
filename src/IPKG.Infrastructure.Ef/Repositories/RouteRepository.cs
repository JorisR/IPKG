using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPKG.Application.Services.Repositories;
using IPKG.Domain;
using Microsoft.EntityFrameworkCore;

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
            return  await _context.Routes.ToListAsync(); 
        }

        public Task<Route> AddRoute(Route route)
        {
            _context.Routes.Add(route);
            return Task.FromResult(route);
        }

        public async Task<Route> GetByReference(Guid reference)
        {
            return await _context.Routes.FirstOrDefaultAsync(x => x.Reference == reference);
        }
    }
}
