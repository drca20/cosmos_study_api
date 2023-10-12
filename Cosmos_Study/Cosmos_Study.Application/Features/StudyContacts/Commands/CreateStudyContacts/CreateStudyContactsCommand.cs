using AutoMapper;
using Cosmos_Study.Application.Exceptions;
using Cosmos_Study.Application.Features.Products.Commands.CreateProduct;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Cosmos_Study.Application.Features.Study.Commands
{
    public partial class CreateStudyContactsCommand : IRequest<Response<Cosmos_Study.Domain.Entities.StudyContacts>>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Gender { get; set; }
        public string PreferedLanguage { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsOpttoEmail { get; set; }
        public bool IsOpttoMobile { get; set; }
        public string WeightUnit { get; set; }
        public string HeightUnit { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double BMI { get; set; }
        public string StudyUniqueId { get; set; }
        public string SiteId { get; set; }
    }

    public class CreateStudyContactsCommandHandler : IRequestHandler<CreateStudyContactsCommand, Response<Cosmos_Study.Domain.Entities.StudyContacts>>
    {
        private readonly IStudyRepositoryAsync _studyRepository;
        private readonly IStudyImageRepositoryAsync _studyImageRepository;
        private readonly IStudyContactsRepositoryAsync _studyContactsRepository;
        private readonly IMapper _mapper;
        public CreateStudyContactsCommandHandler(IStudyRepositoryAsync studyRepository, IStudyImageRepositoryAsync studyImageRepository,IStudyContactsRepositoryAsync studyContactsRepository, IMapper mapper)
        {
            _studyRepository = studyRepository;
            _studyImageRepository = studyImageRepository;
            _studyContactsRepository = studyContactsRepository;
            _mapper = mapper;
        }

        public async Task<Response<Cosmos_Study.Domain.Entities.StudyContacts>> Handle(CreateStudyContactsCommand request, CancellationToken cancellationToken)
        {
            var study = await _studyRepository.GetStudyByInvitationId(request.StudyUniqueId);

            if (study == null)
            {
                throw new ApiException($"Study Not Found.");
            }
            else
            {
                var studyContacts = _mapper.Map<Cosmos_Study.Domain.Entities.StudyContacts>(request);
                studyContacts.StudyId = study.Id;
                await _studyContactsRepository.AddAsync(studyContacts);
                return new Response<Cosmos_Study.Domain.Entities.StudyContacts>(studyContacts);
            }
           
        }
    }
}
