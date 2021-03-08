namespace Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Config
{
    using Microsoft.Extensions.Configuration;

    public class MsSqlConfig
    {
        public string ConnectionString { get; set; }

        public MsSqlConfig()
        {

        }

        public MsSqlConfig(IConfiguration configuration)
        {
            ConnectionString = configuration.GetSection("MsSqlServer").Get<MsSqlConfig>().ConnectionString;
        }

    }
}
