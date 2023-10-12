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

namespace Cosmos_Study.Application.Features.StudyContacts.Queries.GetStudyContacts
{
    public class GetStudyContactsByStudyId : IRequest<Response<List<Cosmos_Study.Domain.Entities.StudyContacts>>>
    {
        public string Id { get; set; }
        public class GetStudyContactsByStudyIdQueryHandler : IRequestHandler<GetStudyContactsByStudyId, Response<List<Cosmos_Study.Domain.Entities.StudyContacts>>>
        {
            private readonly IStudyRepositoryAsync _studyRepository;
            private readonly IStudyContactsRepositoryAsync _studyContactsRepository;
            public GetStudyContactsByStudyIdQueryHandler(IStudyRepositoryAsync studyRepository, IStudyContactsRepositoryAsync studyContactsRepository)
            {
                _studyRepository = studyRepository;
                _studyContactsRepository= studyContactsRepository;
            }
            public async Task<Response<List<Cosmos_Study.Domain.Entities.StudyContacts>>> Handle(GetStudyContactsByStudyId query, CancellationToken cancellationToken)
            {
                var studyContacts = await _studyContactsRepository.GetStudyContactsByStudyId(query.Id);
                if (studyContacts == null) throw new ApiException($"Study Contacts Not Found.");
                return new Response<List<Cosmos_Study.Domain.Entities.StudyContacts>>(studyContacts);
            }
        }
    }
}
