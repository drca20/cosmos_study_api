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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Commands
{
    public partial class CreateStudyCommand : IRequest<Response<Cosmos_Study.Domain.Entities.Study>>
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
        public Site site { get; set; }
    }

    public class CreateStudyCommandHandler : IRequestHandler<CreateStudyCommand, Response<Cosmos_Study.Domain.Entities.Study>>
    {
        private readonly IStudyRepositoryAsync _studyRepository;
        private readonly IStudyImageRepositoryAsync _studyImageRepository;
        private readonly ISiteRepositoryAsync _siteRepository;
        private readonly IMapper _mapper;
        public CreateStudyCommandHandler(IStudyRepositoryAsync studyRepository, IStudyImageRepositoryAsync studyImageRepository, ISiteRepositoryAsync siteRepository, IMapper mapper)
        {
            _studyRepository = studyRepository;
            _studyImageRepository = studyImageRepository;
            _siteRepository = siteRepository;
            _mapper = mapper;
        }

        public async Task<Response<Cosmos_Study.Domain.Entities.Study>> Handle(CreateStudyCommand request, CancellationToken cancellationToken)
        {
            var study = _mapper.Map<Cosmos_Study.Domain.Entities.Study>(request);
            if(request.site != null) {
                var siteObj = await _siteRepository.GetSiteBySiteId(request.site.SiteId);
                if(siteObj == null)
                {
                   await _siteRepository.AddAsync(request.site);
                }
                else
                {
                    siteObj.Website = request.site.Website;
                    siteObj.Description = request.site.Description;
                    siteObj.Name = request.site.Name;
                    await _siteRepository.UpdateAsync(siteObj);
                }
                study.SiteId = request.site.SiteId;
            }

            if (request.Images != null && request.Images.Count > 0)
            {
                study.StudyImages = new List<StudyImage>();
                foreach(var item in request.Images)
                {
                    StudyImage image = new StudyImage();
                    image.StudyUniqueId = study.StudyUniqueId;
                    image.Path = item;
                    study.StudyImages.Add(image);
                }
            }
            await _studyRepository.AddAsync(study);
            return new Response<Cosmos_Study.Domain.Entities.Study>(study);
        }
    }
}
