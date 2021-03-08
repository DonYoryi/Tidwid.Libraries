namespace Tidwit.Libraries.Infra.DataAccess.MSSQLDapper.Shared.Config
{
    using Dapper;
    using System;
    using Domain.Entities;

    public class TableNameResolver : SimpleCRUD.ITableNameResolver
    {
        public string ResolveTableName(Type type)
        {
          
            return string.Format("{0}", type.Name);
        }
    }

}
