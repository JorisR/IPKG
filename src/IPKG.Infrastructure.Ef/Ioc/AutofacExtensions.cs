using Autofac;
using Microsoft.EntityFrameworkCore;


namespace IPKG.Infrastructure.Ef.Ioc
{
    public static class AutofacExtensions
    {
        public static void RegisterEf(this ContainerBuilder containerBuilder, string connectionString)
        {
            containerBuilder.Register(ctx =>
                {
                    var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>().UseSqlServer(connectionString);
                    var options = optionsBuilder.Options;

                    return new DatabaseContext(options, connectionString);
                })
                .AsSelf()
                .InstancePerLifetimeScope();


            containerBuilder.RegisterModule<RepositoryModule>();
        }
    }
}
