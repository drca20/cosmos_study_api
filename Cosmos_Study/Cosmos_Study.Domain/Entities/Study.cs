using Cosmos_Study.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Domain.Entities
{
    public class Study : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string SiteName { get; set; }
        public string Protocol { get; set; }
        public string ProtocolDescription { get; set; }
        public string Compensation { get; set; }
        public string Eligibility { get; set; }
        public string StudyUniqueId { get; set; }
        public bool IsStudyActive { get; set; }
        public List<StudyImage> StudyImages { get; set; }
        public string SiteId { get; set; }
    }
}
