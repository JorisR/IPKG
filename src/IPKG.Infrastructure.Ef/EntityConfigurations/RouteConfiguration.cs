using System;
using System.Collections.Generic;
using System.Text;
using IPKG.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IPKG.Infrastructure.Ef.EntityConfigurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        private const string TableName = "Route";
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable(TableName, DatabaseContext.DefaultSchema);
            builder.HasKey(x=> x.Reference);
        }
    }
}
