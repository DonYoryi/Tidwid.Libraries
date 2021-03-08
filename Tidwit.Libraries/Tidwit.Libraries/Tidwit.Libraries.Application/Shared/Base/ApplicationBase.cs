using System;
using System.Collections.Generic;

namespace Tidwit.Libraries.Application.Shared.Base
{
    using Application.Shared.Interfaces;
    using Application.Helpers;
    using Tidwit.Libraries.Domain.Entities;
    using Tidwit.Libraries.Domain.Shared.Base.Interfaces;
    using Tidwit.Libraries.Application.Dto;

    public class ApplicationBase<TEntity> : IApplicationBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IServiceBase<TEntity> serviceBase;

        public ApplicationBase(IServiceBase<TEntity> serviceBase)
        {
            this.serviceBase = serviceBase;
        }

        protected TEntity CreateWithService(TEntity entity)
        {
                entity.CreatedBy = "admin";
                serviceBase.Create(entity);
                return entity;       
        }

        public Response<TEntity> Create(TEntity entity)
        {
            return ApplicationTry.Try(() =>
            {
                CreateWithService(entity);
                return entity;
            });
        }

        public Response<bool> Delete(int id)
        {
            return ApplicationTry.Try(() =>
            {
                serviceBase.Delete(id);
                return true;
            });
        }

        public Response<IEnumerable<TEntity>> GetAll()
        {
            return ApplicationTry.Try(() =>
            {
                return serviceBase.GetAll();
            });
        }

        public Response<TEntity> GetById(int id)
        {
            return ApplicationTry.Try(() =>
            {
               return serviceBase.GetById(id);
            });
        }

        public Response<bool> Update(TEntity entity)
        {
            return ApplicationTry.Try(() =>
            {
                entity.ModifiedBy = "admin";
                serviceBase.Update(entity);
                return true;
            });
        }
    }
}
