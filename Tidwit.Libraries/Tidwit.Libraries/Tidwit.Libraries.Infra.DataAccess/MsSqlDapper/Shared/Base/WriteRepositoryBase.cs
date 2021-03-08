namespace Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Base
{
    using System;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Dapper;

    using Tidwit.Libraries.Domain.Shared.Base.Interfaces;
    using Tidwit.Libraries.Domain.Entities;
    using Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Config;
    using Tidwit.Libraries.Domain.Shared.Exceptions;
    using Tidwit.Libraries.Domain.Shared.Enums;

    public class WriteRepositoryBase<TEntity> : IWriteRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly string connectionString;

        public WriteRepositoryBase(IConfiguration configuration)
        {
            SimpleCRUD.SetTableNameResolver(new TableNameResolver());
            this.connectionString = new MsSqlConfig(configuration).ConnectionString;
        }

        public void Create(TEntity entity)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Insert<int, TEntity>(entity);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ErrorTypes.DataAcces, ex);
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Update(entity);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ErrorTypes.DataAcces, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                var entity = connection.Get<TEntity>(id);
                connection.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new DomainException(ex.Message, ErrorTypes.DataAcces, ex);
            }
        }


    }
}
