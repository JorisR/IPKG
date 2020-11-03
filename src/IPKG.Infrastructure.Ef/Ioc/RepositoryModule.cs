using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using IPKG.Application.Services.Repositories;
using IPKG.Infrastructure.Ef.Repositories;

namespace IPKG.Infrastructure.Ef.Ioc
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RouteRepository>().As<IRouteRepository>();
        }
    }
}
