using Cosmos_Study.Application.Interfaces.Repositories;
using Cosmos_Study.Domain.Entities;
using Cosmos_Study.Infrastructure.Persistence.Contexts;
using Cosmos_Study.Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Infrastructure.Persistence.Repositories
{
    public class StudyRepositoryAsync : GenericRepositoryAsync<Study>, IStudyRepositoryAsync
    {
        private readonly DbSet<Study> _studies;
        private readonly DbSet<StudyImage> _studyImages;

        public StudyRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _studies = dbContext.Set<Study>();
            _studyImages = dbContext.Set<StudyImage>();
        }

        public Task<Study> GetStudyByInvitationId(string invitationId)
        {
            return _studies
                .FirstOrDefaultAsync(p => p.StudyUniqueId == invitationId);
        }
         public async Task<Study> GetStudyWithImageByInvitationId(string invitationId)
        {
            var study = await  _studies
                .FirstOrDefaultAsync(p => p.StudyUniqueId == invitationId);
            if(study != null)
            {
                study.StudyImages = await _studyImages.Where(x => x.StudyUniqueId == invitationId).ToListAsync();
            }
            return study;
        }

        public Task<bool> IsUniqueStudyId(string studyId)
        {
            return _studies.AllAsync(p => p.StudyUniqueId != studyId);
        }

        public Task<List<Study>> GetAllStudyWithPagination(string siteId,int pageNumber, int pageSize)
        {
            
            return _studies.Where(x=>x.SiteId == siteId && x.IsStudyActive == true).Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();
        }
    }
}
