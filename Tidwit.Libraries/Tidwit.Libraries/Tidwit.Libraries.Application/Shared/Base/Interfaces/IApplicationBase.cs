namespace Tidwit.Libraries.Application.Shared.Interfaces
{
    using System;
    using System.Collections.Generic;
    using Domain.Entities;
    using Tidwit.Libraries.Application.Dto;

    public interface IApplicationBase<TEntity> where TEntity : EntityBase
    {
        Response<TEntity> Create(TEntity entity);
        Response<bool> Update(TEntity entity);
        Response<bool> Delete(int id);
        Response<TEntity> GetById(int id);
        Response<IEnumerable<TEntity>> GetAll();
    }
}
