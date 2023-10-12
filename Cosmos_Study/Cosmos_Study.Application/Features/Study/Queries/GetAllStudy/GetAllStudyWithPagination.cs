using AutoMapper;
using Cosmos_Study.Application.Exceptions;
using Cosmos_Study.Application.Features.Products.Queries.GetAllProducts;
using Cosmos_Study.Application.Interfaces;
using Cosmos_Study.Application.Interfaces.Repositories;
using Cosmos_Study.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Queries.GetAllStudy
{
    public class GetAllStudyWithPagination : IRequest<PagedResponse<IEnumerable<GetAllStudyViewModel>>>
    {
        public string EmbeddedId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllStudyWithPaginationHandler : IRequestHandler<GetAllStudyWithPagination, PagedResponse<IEnumerable<GetAllStudyViewModel>>>
    {
        private readonly IStudyRepositoryAsync _studyRepository;
        private readonly ISiteRepositoryAsync _siteRepository;
        private readonly IAuthenticatedUserService _authenticatedService;
        private readonly IMapper _mapper;
        public GetAllStudyWithPaginationHandler(IStudyRepositoryAsync studyRepository, ISiteRepositoryAsync siteRepositoryAsync, IAuthenticatedUserService authenticatedService, IMapper mapper)
        {
            _studyRepository = studyRepository;
            _authenticatedService = authenticatedService;
            _siteRepository= siteRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllStudyViewModel>>> Handle(GetAllStudyWithPagination request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_authenticatedService.Domain))
            {
                throw new ApiException($"Domain is not authenticated to get data.");
            }
            var siteObj = await _siteRepository.GetSiteByDomain(_authenticatedService.Domain, request.EmbeddedId);
            if (siteObj == null) { throw new ApiException($"Domain is not authenticated to get data."); }
            var validFilter = _mapper.Map<GetAllStudyParameter>(request);
            var study = await _studyRepository.GetAllStudyWithPagination(validFilter.EmbeddedId, validFilter.PageNumber, validFilter.PageSize);
            var studyViewModel = _mapper.Map<IEnumerable<GetAllStudyViewModel>>(study);
            return new PagedResponse<IEnumerable<GetAllStudyViewModel>>(studyViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
