using System;

namespace Tidwit.Libraries.Domain.Shared.Exceptions
{
    using Enums;

    public class DomainException: Exception
    {
        private readonly ErrorTypes errorType;
        public ErrorTypes ErrorType { get { return errorType;  } }

        public DomainException(string message, ErrorTypes errorType) : base(message)
        {
            this.errorType = errorType;
        }

        public DomainException(string message, ErrorTypes errorType,Exception innerException) : base(message, innerException)
        {
            this.errorType = errorType;
        }

    }
}
