namespace Tidwit.Libraries.Api.Config.Mappers
{
    using AutoMapper;
    using Tidwit.Libraries.Api.Models;
    using Tidwit.Libraries.Domain.Entities.Library;

    public class MappingProfileConfiguration : Profile
    {
        public MappingProfileConfiguration()
        {
            CreateMap<LibraryModel, Library>().ReverseMap();
        }
    }
}
