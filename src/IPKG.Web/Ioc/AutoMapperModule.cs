using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Module = Autofac.Module;

namespace IPKG.Web.Ioc
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Program)))
                .Where(t => t.BaseType == typeof(Profile)
                            && !t.IsAbstract)
                .As<Profile>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in ctx.Resolve<IEnumerable<Profile>>())
                    cfg.AddProfile(profile);
            }));


            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper(t => ctx.Resolve(t))).As<IMapper>();
        }
    }
}
