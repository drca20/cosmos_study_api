using Cosmos_Study.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Interfaces.Repositories
{
    public interface IStudyImageRepositoryAsync : IGenericRepositoryAsync<StudyImage>
    {
        Task<StudyImage> InsertStudyImages(StudyImage image);
        Task<bool> DeleteStudyImagesbyStudyId(string studyId);
    }
}
