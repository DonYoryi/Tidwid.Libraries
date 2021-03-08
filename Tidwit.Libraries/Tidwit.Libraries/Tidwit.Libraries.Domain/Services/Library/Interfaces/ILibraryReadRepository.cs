

namespace Tidwit.Libraries.Domain.Services.Library
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tidwit.Libraries.Domain.Shared.Base.Interfaces;
    using Tidwit.Libraries.Domain.Entities.Library;
    using Tidwit.Libraries.Domain.Dtos;

    public interface ILibraryReadRepository : IReadRepository<Library>
    {
        PageDto<Library> FindByGenre(int idGenre, int page, int pageSize);
    }
}
