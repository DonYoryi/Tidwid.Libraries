using System;

namespace Tidwit.Libraries.Application.Helpers
{

    using Domain.Shared.Enums;
    using Domain.Shared.Exceptions;
    using Tidwit.Libraries.Application.Dto;

    public static class ApplicationTry
    {

        public static Response<T> Try<T>(Func<T> action)
        {
            var response = new Response<T>();
            try
            {
                response.Entity = action();
                response.IsSuccess = true;
                response.ErrorType = ErrorTypes.Success;
            }
            catch (DomainException ex)
            {
                response.ErrorMessage = ex.Message;
                response.ErrorType = ex.ErrorType;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.ErrorType = ErrorTypes.UndefindedError;
            }

            return response;
        }
    }
}
