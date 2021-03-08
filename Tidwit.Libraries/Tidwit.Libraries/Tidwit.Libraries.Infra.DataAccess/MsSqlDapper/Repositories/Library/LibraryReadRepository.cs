

namespace Tidwit.Libraries.Infra.DataAccess.MsSqlDapper.Repositories.Library
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tidwit.Libraries.Domain.Services.Library;
    using Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Base;
    using Tidwit.Libraries.Domain.Entities.Library;
    using Microsoft.Extensions.Configuration;
    using System.Data.SqlClient;
    using Tidwit.Libraries.Domain.Dtos;
    using Dapper;

    public class LibraryReadRepository : ReadRepositoryBase<Library>, ILibraryReadRepository
    {
        public LibraryReadRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public PageDto<Library> FindByGenre(int idGenre, int page, int pageSize)
        {
            using var connection = new SqlConnection(connectionString);
            var results = connection.GetListPaged<Library>(page, pageSize, "", string.Empty);
            var totalResults = connection.RecordCount<Library>();

            return new PageDto<Library>()
            {
                Results = results,
                TotalResults = totalResults
            };
        }
    }
}
