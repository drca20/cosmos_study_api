using Cosmos_Study.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Interfaces.Repositories
{
    public interface IStudyRepositoryAsync : IGenericRepositoryAsync<Study>
    {
        Task<Study> GetStudyByInvitationId(string invitationId);
        Task<Study> GetStudyWithImageByInvitationId(string invitationId);
        Task<List<Study>> GetAllStudyWithPagination(string invitationId, int pageNumber, int pageSize);
        Task<bool> IsUniqueStudyId(string invitationId);
    }
}
