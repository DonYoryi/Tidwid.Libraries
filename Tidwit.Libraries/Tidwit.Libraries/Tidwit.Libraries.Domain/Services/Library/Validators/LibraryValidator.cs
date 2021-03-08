

namespace Tidwit.Libraries.Domain.Services.Library.Validators
{
    using Tidwit.Libraries.Domain.Entities.Library;
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    public class LibraryValidator : AbstractValidator<Library>
    {
        private readonly ILibraryReadRepository libraryReadRepository;
        public LibraryValidator(ILibraryReadRepository libraryReadRepository)
        {
            this.libraryReadRepository = libraryReadRepository;
            this.Validator();
        }
        private void Validator()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("name is empty");
            RuleFor(x => x.Name).NotNull().WithMessage("name is empty");
            RuleFor(x => x.PublishDate).NotEmpty().WithMessage("Publish Date is empty");
            RuleFor(x => x.PublishDate).NotNull().WithMessage("Publish Date is empty");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Language is empty");
            RuleFor(x => x.Language).NotNull().WithMessage("Language is empty");
            RuleFor(x => x.UrlImage).NotEmpty().WithMessage("Image is empty");
            RuleFor(x => x.UrlImage).NotNull().WithMessage("Image is empty");
            RuleFor(x => x).Must(DuplicateUserName).WithMessage("name already assigned");
        }


        private bool DuplicateUserName(Library user)
        {
            if (user.Id == 0)
            {
                return !this.libraryReadRepository.GetFor("Library", "name", user.Name).Any();
            }
            return true;
        }
    }
}
