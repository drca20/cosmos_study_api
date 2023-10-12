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

namespace Cosmos_Study.Application.Features.Study.Commands
{
    public class UpdateStudyCommand : IRequest<Response<Cosmos_Study.Domain.Entities.Study>>
    {
        public string Name { get; set; }
        public string SiteName { get; set; }
        public string Protocol { get; set; }
        public string ProtocolDescription { get; set; }
        public string Compensation { get; set; }
        public string Eligibility { get; set; }
        public string StudyUniqueId { get; set; }
        public bool IsStudyActive { get; set; }
        public List<string> Images { get; set; }
        public class UpdateStudyCommandHandler : IRequestHandler<UpdateStudyCommand, Response<Cosmos_Study.Domain.Entities.Study>>
        {
            private readonly IStudyRepositoryAsync _studyRepository;
            private readonly IStudyImageRepositoryAsync _studyImageRepository;
            public UpdateStudyCommandHandler(IStudyRepositoryAsync studyRepository, IStudyImageRepositoryAsync studyImageRepository)
            {
                _studyRepository = studyRepository;
                _studyImageRepository = studyImageRepository;
            }
            public async Task<Response<Cosmos_Study.Domain.Entities.Study>> Handle(UpdateStudyCommand command, CancellationToken cancellationToken)
            {
                var study = await _studyRepository.GetStudyByInvitationId(command.StudyUniqueId);

                if (study == null)
                {
                    throw new ApiException($"Study Not Found.");
                }
                else
                {
                    study.Name = command.Name;
                    study.SiteName = command.SiteName;
                    study.Protocol = command.Protocol;
                    study.ProtocolDescription = command.ProtocolDescription;
                    study.Compensation = command.Compensation;
                    study.Eligibility = command.Eligibility;
                    study.IsStudyActive = command.IsStudyActive;
                    if (command.Images != null && command.Images.Count > 0)
                    {
                        await _studyImageRepository.DeleteStudyImagesbyStudyId(command.StudyUniqueId);
                        study.StudyImages = new List<StudyImage>();
                        foreach (var item in command.Images)
                        {
                            StudyImage image = new StudyImage();
                            image.StudyUniqueId = study.StudyUniqueId;
                            image.Path = item;
                            image.StudyId = study.Id;
                            study.StudyImages.Add(await _studyImageRepository.InsertStudyImages(image));
                        }
                    }
                    await _studyRepository.UpdateAsync(study);
                    
                    return new Response<Cosmos_Study.Domain.Entities.Study>(study);
                }
            }
        }
    }
}
