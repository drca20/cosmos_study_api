using Cosmos_Study.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Interfaces.Repositories
{
    public interface IStudyContactsRepositoryAsync : IGenericRepositoryAsync<StudyContacts>
    {
        Task<List<StudyContacts>> GetStudyContactsByStudyId(string studyUniqueId);
    }
}
