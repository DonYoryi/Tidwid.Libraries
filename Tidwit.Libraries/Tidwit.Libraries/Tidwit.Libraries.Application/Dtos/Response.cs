namespace Tidwit.Libraries.Application.Dto
{
    using Domain.Shared.Enums;    

    public class Response<TEntity>
    {
        public TEntity Entity { get; set; }
        public bool IsSuccess { set; get; }
        public string ErrorMessage {get;set;}
        public ErrorTypes ErrorType { get; set; }
    }
}
