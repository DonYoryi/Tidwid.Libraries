namespace Tidwit.Libraries.Api.Controllers
{
    using AutoMapper;
    using Tidwit.Libraries.Application.Shared.Interfaces;
    using Tidwit.Libraries.Domain.Entities;
    using Tidwit.Libraries.Domain.Shared.Exceptions;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Tidwit.Libraries.Application.Dto;

    /// <summary>
    /// Defines the <see cref="ControllerBase{TEntity, TModel}" />.
    /// </summary>
    /// <typeparam name="TEntity">.</typeparam>
    /// <typeparam name="TModel">.</typeparam>

    public class ControllerBase<TEntity, TModel> : ControllerBase where TEntity : EntityBase
    {
        /// <summary>
        /// Defines the applicationBase.
        /// </summary>
        private readonly IApplicationBase<TEntity> applicationBase;

        /// <summary>
        /// Defines the mapper.
        /// </summary>
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ControllerBase{TEntity, TModel}"/> class.
        /// </summary>
        /// <param name="applicationBase">The applicationBase<see cref="IApplicationBase{TEntity}"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        public ControllerBase(IApplicationBase<TEntity> applicationBase, IMapper mapper)
        {
            this.applicationBase = applicationBase;
            this.mapper = mapper;
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="TEntity"/>.</returns>
        [HttpGet("{id}")]
        public Response<TEntity> Get(int id)
        {
            var response = this.applicationBase.GetById(id);
            ValidateRespose(response);
            return response;
        }

        /// <summary>
        /// The Get.
        /// </summary>
        /// <returns>The <see cref="IEnumerable{TEntity}"/>.</returns>
        [HttpGet]
        public virtual Response<IEnumerable<TEntity>> Get()
        {
            var response = this.applicationBase.GetAll();
            ValidateRespose(response);
            return response;
        }

        /// <summary>
        /// The Post.
        /// </summary>
        /// <param name="model">The model<see cref="TModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public Response<TEntity> Create([FromBody] TModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            var response = this.applicationBase.Create(entity);
            ValidateRespose(response);
            return response;
        }

        /// <summary>
        /// The Put.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <param name="model">The model<see cref="TModel"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public Response<bool> Update([FromRoute] int id, [FromBody] TModel model)
        {
            var entity = mapper.Map<TEntity>(model);
            entity.Id = id;
            var response = this.applicationBase.Update(entity);
            ValidateRespose(response);
            return response;
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="Guid"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public Response<bool> Delete(int id)
        {
            var response = this.applicationBase.Delete(id);
            ValidateRespose(response);
            return response;
        }

        /// <summary>
        /// The ValidateRespose.
        /// </summary>
        /// <typeparam name="TResponse">.</typeparam>
        /// <param name="response">The response<see cref="Response{TResponse}"/>.</param>
        public void ValidateRespose<TResponse>(Response<TResponse> response)
        {
            if (!response.IsSuccess)
            {
                throw new DomainException(response.ErrorMessage, response.ErrorType);
            }
        }
    }
}
