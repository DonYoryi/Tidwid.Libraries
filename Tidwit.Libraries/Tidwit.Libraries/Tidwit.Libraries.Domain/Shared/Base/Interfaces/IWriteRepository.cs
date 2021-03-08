namespace Tidwit.Libraries.Domain.Shared.Base.Interfaces
{
    using System;
    using Entities;

    public interface IWriteRepository<TEntity> where TEntity : EntityBase
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
