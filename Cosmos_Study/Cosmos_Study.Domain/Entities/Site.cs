using Cosmos_Study.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Domain.Entities
{
    public class Site : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string SiteId { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }

    }
}
