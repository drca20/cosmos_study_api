using Cosmos_Study.Application.Exceptions;
using Cosmos_Study.Application.Interfaces.Repositories;
using Cosmos_Study.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Commands
{
    public class DeleteStudyByIdCommand : IRequest<Response<int>>
    {
        public string Id { get; set; }
        public class DeleteStudyByIdCommandHandler : IRequestHandler<DeleteStudyByIdCommand, Response<int>>
        {
            private readonly IStudyRepositoryAsync _studyRepository;
            private readonly IStudyImageRepositoryAsync _studyImageRepository;
            public DeleteStudyByIdCommandHandler(IStudyRepositoryAsync studyRepository, IStudyImageRepositoryAsync studyImageRepository)
            {
                _studyRepository = studyRepository;
                _studyImageRepository = studyImageRepository;
            }
            public async Task<Response<int>> Handle(DeleteStudyByIdCommand command, CancellationToken cancellationToken)
            {
                var study = await _studyRepository.GetStudyByInvitationId(command.Id);
                if (study == null) throw new ApiException($"Study Not Found.");
                study.IsStudyActive = false;
                await _studyRepository.UpdateAsync(study);
                return new Response<int>(study.Id);
            }
        }
    }
}
