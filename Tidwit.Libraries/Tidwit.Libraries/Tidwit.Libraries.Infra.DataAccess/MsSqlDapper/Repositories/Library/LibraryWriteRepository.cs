

namespace Tidwit.Libraries.Infra.DataAccess.MsSqlDapper.Repositories.Library
{
    using Dapper;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Data.SqlClient;
    using Tidwit.Libraries.Domain.Entities.Library;
    using Tidwit.Libraries.Domain.Services.Library;
    using Tidwit.Libraries.Domain.Shared.Enums;
    using Tidwit.Libraries.Domain.Shared.Exceptions;
    using Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Base;

    public class LibraryWriteRepository : WriteRepositoryBase<Library>, ILibraryWriteRepository
    {
        public LibraryWriteRepository(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
