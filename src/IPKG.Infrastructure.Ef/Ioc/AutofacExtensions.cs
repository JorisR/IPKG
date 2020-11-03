using Autofac;


namespace IPKG.Infrastructure.Ef.Ioc
{
    public static class AutofacExtensions
    {
        public static void RegisterEf(this ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<RepositoryModule>();
        }
    }
}
