using Cosmos_Study.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Interfaces.Repositories
{
    public interface ISiteRepositoryAsync : IGenericRepositoryAsync<Site>
    {
        Task<Site> GetSiteBySiteId(string siteId);
        Task<Site> GetSiteByDomain(string domain,string siteId);
    }
}
