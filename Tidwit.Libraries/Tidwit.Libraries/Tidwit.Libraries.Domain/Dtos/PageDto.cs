namespace Tidwit.Libraries.Domain.Dtos
{
    using System.Collections.Generic;

    public class PageDto<TResults>
    {
        public IEnumerable<TResults> Results { get; set; }
        public int TotalResults { get; set; }
    }
}
