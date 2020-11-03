using System;
using System.Collections.Generic;
using System.Text;
using Autofac;

namespace IPKG.Application.Services.Ioc
{
    public static class AutofacExtensions
    {
        public static void RegisterServices(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<ServicesModule>();
        }
    }
}
