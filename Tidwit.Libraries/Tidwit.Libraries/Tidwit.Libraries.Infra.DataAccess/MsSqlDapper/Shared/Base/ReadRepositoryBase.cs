namespace Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Base
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using Microsoft.Extensions.Configuration;
    using Dapper;
    using Domain.Entities;
    using Domain.Shared.Base.Interfaces;
    using Tidwit.Libraries.Domain.Dtos;
    using Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Config;
    using System.Linq;

    public class ReadRepositoryBase<TEntity> : IReadRepository<TEntity> where TEntity : EntityBase
    {
        protected readonly string connectionString;

        public ReadRepositoryBase(IConfiguration configuration)
        {
            SimpleCRUD.SetTableNameResolver(new TableNameResolver());
            this.connectionString = new MsSqlConfig(configuration).ConnectionString;
        }

        public IEnumerable<TEntity> GetAll()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.GetList<TEntity>();
        }

        public TEntity GetById(int id)
        {
            using var connection = new SqlConnection(connectionString);
            return connection.Get<TEntity>(id);
        }

        public int Count()
        {
            using var connection = new SqlConnection(connectionString);
            return connection.RecordCount<TEntity>();
        }

        public PageDto<TEntity> GetByPage(int page, int pageSize)
        {
            using var connection = new SqlConnection(connectionString);
            var results = connection.GetListPaged<TEntity>(page, pageSize, string.Empty, string.Empty);
            var totalResults =  connection.RecordCount<TEntity>();

            return new PageDto<TEntity>()
            {
                Results = results,
                TotalResults = totalResults
            };
        }

        public List<TEntity> GetFor(string table, string column, string value)
        {
            string sql = string.Format("Select * from {0} where {1} = '{2}'", table, column, value);
            using var connection = new SqlConnection(connectionString);
            return connection.Query<TEntity>(sql).ToList();
        }
    }
}
