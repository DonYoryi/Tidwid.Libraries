using System;

namespace Tidwit.Libraries.Domain.Shared.Base
{
    using System.Collections.Generic;
    using FluentValidation;
    using Domain.Shared.Exceptions;
    using Domain.Shared.Enums;
    using Domain.Shared.Base.Interfaces;
    using Domain.Entities;

    public class ServiceBase<TEntity>: IServiceBase<TEntity> where TEntity : EntityBase
    {
        protected readonly IReadRepository<TEntity> readRepository;
        protected readonly IWriteRepository<TEntity> writeRepository;
        protected readonly AbstractValidator<TEntity> validator;

        public ServiceBase(IReadRepository<TEntity> readRepository, 
                            IWriteRepository<TEntity> writeRepository,
                            AbstractValidator<TEntity> validator)
        {
            this.readRepository = readRepository;
            this.writeRepository = writeRepository;
            this.validator = validator;
        }

        public virtual TEntity Create(TEntity entity)
        {
            PreCreate(entity);
            writeRepository.Create(entity);
            return entity;
        }

        public TEntity PreCreate(TEntity entity)
        {
            entity.Id = 0;
            entity.CreatedAt = DateTime.Now;
            ValideEntity(entity);
            return entity;
        }

        public void Delete(int id)
        {
            Exist(id);
            writeRepository.Delete(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return readRepository.GetAll();
        }

        public virtual TEntity GetById(int id)
        {
            return Exist(id);
        }

        public void Update(TEntity entity)
        {
            PreUpdate(entity);
            writeRepository.Update(entity);
        }

        public TEntity PreUpdate(TEntity entity)
        {
            var oldEntity = Exist(entity.Id);
            entity.ModifiedAt = DateTime.Now;
            entity.CreatedAt = oldEntity.CreatedAt;
            entity.CreatedBy = oldEntity.CreatedBy;
            ValideEntity(entity);
            return entity;
        }

        private void ValideEntity(TEntity entity)
        {
            var validation = validator.Validate(entity);
            if (!validation.IsValid)
            {
                throw new DomainException(validation.Errors[0].ErrorMessage, ErrorTypes.InvalidEntity);
            }
        }

        public TEntity Exist(int id)
        {
            var entity = readRepository.GetById(id);
            if (entity == null)
            {
                throw new DomainException("Entity not found", ErrorTypes.EntityNotFound);
            }
            return entity;
        }

    }
}
