namespace Tidwit.Libraries.Infra.Ioc.Installers
{

    using Microsoft.Extensions.DependencyInjection;
    using Tidwit.Libraries.Application.Services.Library.Interfaces;
    using Tidwit.Libraries.Application.Services.Library;

    /// <summary>
    /// Defines the <see cref="ApplicationInstallers" />.
    /// </summary>
    public static class ApplicationInstallers
    {
        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<ILibraryApplication, LibraryApplication>();

        }
    }
}
