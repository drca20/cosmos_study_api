using Cosmos_Study.Application.Exceptions;
using Cosmos_Study.Application.Interfaces.Repositories;
using Cosmos_Study.Application.Wrappers;
using Cosmos_Study.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Queries
{
    public class GetStudyByIdQuery : IRequest<Response<Cosmos_Study.Domain.Entities.Study>>
    {
        public string Id { get; set; }
        public class GetStudyByIdQueryQueryHandler : IRequestHandler<GetStudyByIdQuery, Response<Cosmos_Study.Domain.Entities.Study>>
        {
            private readonly IStudyRepositoryAsync _studyRepository;
            public GetStudyByIdQueryQueryHandler(IStudyRepositoryAsync studyRepository)
            {
                _studyRepository = studyRepository;
            }
            public async Task<Response<Cosmos_Study.Domain.Entities.Study>> Handle(GetStudyByIdQuery query, CancellationToken cancellationToken)
            {
                var study = await _studyRepository.GetStudyWithImageByInvitationId(query.Id);
                if (study == null) throw new ApiException($"Study Not Found.");
                return new Response<Cosmos_Study.Domain.Entities.Study>(study);
            }
        }
    }
}
