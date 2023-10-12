using Cosmos_Study.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Domain.Entities
{
    public class StudyImage : AuditableBaseEntity
    {
        public string StudyUniqueId { get; set; }
        public string Path { get; set; }
        public int StudyId { get; set; }
    }
}
