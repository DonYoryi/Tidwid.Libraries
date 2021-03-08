namespace Tidwit.Libraries.Infra.DataAccess.MsSqlDapper.Shared.Base
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Config;

    public class RepositoryBase
    {
        protected readonly string connectionString;

        public RepositoryBase(IConfiguration configuration)
        {
            SimpleCRUD.SetTableNameResolver(new TableNameResolver());
            this.connectionString = new MsSqlConfig(configuration).ConnectionString;
        }
    }
}
