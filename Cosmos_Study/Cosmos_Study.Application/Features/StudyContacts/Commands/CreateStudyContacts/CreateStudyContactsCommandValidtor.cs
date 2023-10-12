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
  
    public class CreateStudyContactsCommandValidtor : AbstractValidator<CreateStudyContactsCommand>
    {
        private readonly IStudyRepositoryAsync studyRepository;

        public CreateStudyContactsCommandValidtor(IStudyRepositoryAsync studyRepository)
        {
            this.studyRepository = studyRepository;

            //RuleFor(p => p.SponsorSiteStudyCDAInvitationId)
            //    .NotEmpty().WithMessage("{PropertyName} is required.")
            //    .NotNull()
            //    .MustAsync(IsUniqueStudyId).WithMessage("{PropertyName} already exists.");

        }

        private async Task<bool> IsUniqueStudyId(string studyId, CancellationToken cancellationToken)
        {
            return await studyRepository.IsUniqueStudyId(studyId);
        }
    }
}
