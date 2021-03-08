

namespace Tidwit.Libraries.Domain.Services.Library
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tidwit.Libraries.Domain.Shared.Base;
    using Tidwit.Libraries.Domain.Entities.Library;
    using Tidwit.Libraries.Domain.Entities.Library.Interfaces;
    using Tidwit.Libraries.Domain.Services.Library.Validators;

    public class LibraryService : ServiceBase<Library>, ILibraryService
    {

        public LibraryService(
            ILibraryReadRepository libraryReadRepository, 
            ILibraryWriteRepository libraryWriteRepository,
            LibraryValidator libraryValidator
            ) : base(libraryReadRepository, libraryWriteRepository, libraryValidator)
        {
        }

    }
}
