namespace Tidwit.Libraries.Infra.Ioc.Installers
{

    using Microsoft.Extensions.DependencyInjection;
    using Tidwit.Libraries.Domain.Entities.Library.Interfaces;
    using Tidwit.Libraries.Domain.Services.Library;
    using Tidwit.Libraries.Domain.Services.Library.Validators;

    /// <summary>
    /// Defines the <see cref="DomainInstallers" />.
    /// </summary>
    public static class DomainInstallers
    {
        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<ILibraryService, LibraryService>();
            services.AddTransient<LibraryValidator>();
        }
    }
}
