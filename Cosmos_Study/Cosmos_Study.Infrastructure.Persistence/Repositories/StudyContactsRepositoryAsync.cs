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
    public class StudyContactsRepositoryAsync : GenericRepositoryAsync<StudyContacts>, IStudyContactsRepositoryAsync
    {
        private readonly DbSet<StudyContacts> _studycontacts;

        public StudyContactsRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _studycontacts = dbContext.Set<StudyContacts>();
        }

        public Task<List<StudyContacts>> GetStudyContactsByStudyId(string studyUniqueId)
        {
            return  _studycontacts.Where(x=>x.StudyUniqueId == studyUniqueId).ToListAsync();
        }
    }
}
