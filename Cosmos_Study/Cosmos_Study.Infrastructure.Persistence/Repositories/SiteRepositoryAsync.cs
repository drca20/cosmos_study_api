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
    public class SiteRepositoryAsync : GenericRepositoryAsync<Site>, ISiteRepositoryAsync
    {
        private readonly DbSet<Site> _site;

        public SiteRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _site = dbContext.Set<Site>();
        }
        public Task<Site> GetSiteBySiteId(string SiteId)
        {
            return _site.FirstOrDefaultAsync(x=>x.SiteId == SiteId);
        }
        public Task<Site> GetSiteByDomain(string domain,string SiteId)
        {
            return _site.FirstOrDefaultAsync(x=>x.SiteId == SiteId && x.Website == domain);
        }
    }
}
