namespace Tidwit.Libraries.Api.Controllers.Library
{
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using Tidwit.Libraries.Api.Models;
    using Tidwit.Libraries.Domain.Entities.Library;
    using Tidwit.Libraries.Application.Services.Library.Interfaces;

    /// <summary>
    /// Defines the <see cref="LibraryController" />.
    /// </summary>
    [Route("[controller]")]
    public class LibraryController : ControllerBase<Library, LibraryModel>
    {
        private readonly ILibraryApplication libraryApplication;
        IMapper mapper;
        public LibraryController(ILibraryApplication libraryApplication, IMapper mapper) : base(libraryApplication, mapper)
        {
            this.libraryApplication = libraryApplication;
            this.mapper = mapper;
        }
    }
}
