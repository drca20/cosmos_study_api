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
    public class StudyImageRepositoryAsync : GenericRepositoryAsync<StudyImage>, IStudyImageRepositoryAsync
    {
        private readonly DbSet<StudyImage> _studyimages;

        public StudyImageRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _studyimages = dbContext.Set<StudyImage>();
        }

        public async Task<StudyImage> InsertStudyImages(StudyImage image)
        {
            await _studyimages.AddAsync(image);
            return image;
        }

        public Task<bool> DeleteStudyImagesbyStudyId(string studyId)
        {
            _studyimages.RemoveRange(_studyimages.Where(x => x.StudyUniqueId == studyId));
            return Task<bool>.FromResult(true);
        }
    }
}
