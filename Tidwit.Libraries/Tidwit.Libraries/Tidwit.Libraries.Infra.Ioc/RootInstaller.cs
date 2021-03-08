
namespace Tidwit.Libraries.Infra.Ioc
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tidwit.Libraries.Infra.Ioc.Installers;

    public static class RootInstaller
    {

        public static void Install(IServiceCollection services,IConfiguration configuration)
        {
           RepositoriesInstaller.Install(services);
           DomainInstallers.Install(services);
           ApplicationInstallers.Install(services);
        }

    }
}
