using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using IPKG.Application.Services.Implementations;
using IPKG.Application.Services.Interfaces;

namespace IPKG.Application.Services.Ioc
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ParkingService>().As<IParkingService>();
            builder.RegisterType<RouteService>().As<IRouteService>();
        }
    }
}
