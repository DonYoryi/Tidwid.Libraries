namespace Tidwit.Libraries.Api.Middlewares
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System;
    using System.Threading.Tasks;

    using Models;
    using System.Net;
    using Domain.Shared.Enums;
    using Domain.Shared.Exceptions;

    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task Invoke(HttpContext context)
        {
            ErrorResponse errorResponse = null;
            var instance = context.Request.Path;
            try
            {
                await _next.Invoke(context);
            }
            catch (DomainException ex)
            {
                if(ex.ErrorType == ErrorTypes.EntityNotFound)
                {
                    errorResponse = new ErrorResponse(ex.Message, (int)HttpStatusCode.NotFound, instance);
                }
                else
                {
                    errorResponse = new ErrorResponse(ex.Message, (int)HttpStatusCode.BadRequest, instance);
                }
                
            }
            catch (Exception ex)
            {
               _logger.LogError( ex, ex.Message);
                errorResponse = new ErrorResponse(ex.Message, (int)HttpStatusCode.InternalServerError, instance);
            }

            if (!context.Response.HasStarted && errorResponse != null)
            {
                await CreateErrorResponse(context, errorResponse);
            }
        }

        private static async Task CreateErrorResponse(HttpContext context,ErrorResponse errorModel)
        {
            context.Response.StatusCode = errorModel.Status;
            context.Response.ContentType = "application/json";
            var json = JsonConvert.SerializeObject(errorModel);
            await context.Response.WriteAsync(json);
        }

    }
}
