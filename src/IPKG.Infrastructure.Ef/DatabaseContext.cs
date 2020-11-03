using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using IPKG.Application.Services.Repositories;
using IPKG.Domain;
using NetTopologySuite.Geometries;

namespace IPKG.Infrastructure.Ef
{
    public class DatabaseContext : IUnitOfWork
    {
        public DatabaseContext()
        {
            Routes = new List<Route>();
        }
        public List<Route> Routes { get; set; }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await Task.FromResult(0);
        }
    }
}
