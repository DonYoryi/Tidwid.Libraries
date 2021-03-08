

namespace Tidwit.Libraries.Application.Services.Library
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Tidwit.Libraries.Application.Services.Library.Interfaces;
    using Tidwit.Libraries.Application.Shared.Base;
    using Tidwit.Libraries.Domain.Entities.Library.Interfaces;
    using Tidwit.Libraries.Domain.Entities.Library;
    public class LibraryApplication : ApplicationBase<Library>, ILibraryApplication
    {
        public readonly ILibraryService userService;
        public LibraryApplication(ILibraryService libraryService) : base(libraryService)
        {
        }
    
    }
}
