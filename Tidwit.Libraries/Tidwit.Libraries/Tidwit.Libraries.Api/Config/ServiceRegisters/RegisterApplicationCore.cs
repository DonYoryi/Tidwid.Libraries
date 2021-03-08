namespace Tidwit.Libraries.Api.Config
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Tidwit.Libraries.Infra.Ioc;

    public class RegisterApplicationCore : IServiceRegistration
    {
        public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
        {
            RootInstaller.Install(services, configuration);
        }
    }

}
