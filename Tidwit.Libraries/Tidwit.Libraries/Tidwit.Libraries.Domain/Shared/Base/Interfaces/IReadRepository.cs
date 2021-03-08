namespace Tidwit.Libraries.Domain.Shared.Base.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities;
    using Domain.Dtos;

    public interface IReadRepository<TEntity> where TEntity : EntityBase
    {
        TEntity  GetById(int id);

        IEnumerable<TEntity> GetAll();

        List<TEntity> GetFor(string table, string column, string value);

        PageDto<TEntity> GetByPage(int page,int pageSize);

        int Count();
    }
}
