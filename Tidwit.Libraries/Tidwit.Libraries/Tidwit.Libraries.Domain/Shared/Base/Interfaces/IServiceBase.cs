
namespace Tidwit.Libraries.Domain.Shared.Base.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities;

    public interface IServiceBase<TEntity> where TEntity : EntityBase
    {
        TEntity Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity GetById(int id);
        TEntity Exist(int id);
        IEnumerable<TEntity> GetAll();
    }
}
