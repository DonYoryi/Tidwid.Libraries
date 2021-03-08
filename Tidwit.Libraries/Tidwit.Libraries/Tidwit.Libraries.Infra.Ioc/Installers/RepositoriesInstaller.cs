namespace Tidwit.Libraries.Infra.Ioc.Installers
{
    using Microsoft.Extensions.DependencyInjection;
    using Tidwit.Libraries.Domain.Services.Library;
    using Tidwit.Libraries.Infra.DataAccess.MsSqlDapper.Repositories.Library;


    /// <summary>
    /// Defines the <see cref="RepositoriesInstaller" />.
    /// </summary>
    public static class RepositoriesInstaller
    {
        /// <summary>
        /// The Install.
        /// </summary>
        /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
        public static void Install(IServiceCollection services)
        {
            services.AddTransient<ILibraryReadRepository, LibraryReadRepository>();
            services.AddTransient<ILibraryWriteRepository, LibraryWriteRepository>();
        }
    }
}
