using Cosmos_Study.Application.Features.Products.Commands.CreateProduct;
using Cosmos_Study.Application.Interfaces.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Commands.CreateStudy
{
  
    public class CreateStudyCommandValidtor : AbstractValidator<CreateStudyCommand>
    {
        private readonly IStudyRepositoryAsync studyRepository;

        public CreateStudyCommandValidtor(IStudyRepositoryAsync studyRepository)
        {
            this.studyRepository = studyRepository;

            RuleFor(p => p.StudyUniqueId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(IsUniqueStudyId).WithMessage("{PropertyName} already exists.");

            RuleFor(p => p.site)
                .NotEmpty().WithMessage("{PropertyName} is required.");

            When(p => p.site != null, () =>
            {
                RuleFor(p => p.site.SiteId)
              .NotEmpty().WithMessage("{PropertyName} is required.");

                RuleFor(p => p.site.Website)
                   .NotEmpty().WithMessage("{PropertyName} is required.");

            });

           

        }

        private async Task<bool> IsUniqueStudyId(string studyId, CancellationToken cancellationToken)
        {
            return await studyRepository.IsUniqueStudyId(studyId);
        }
    }
}
