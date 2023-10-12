using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Queries.GetAllStudy
{
    public class GetAllStudyViewModel
    {
        public string Name { get; set; }
        public string SiteName { get; set; }
        public string Protocol { get; set; }
        public string ProtocolDescription { get; set; }
        public string Compensation { get; set; }
        public string Eligibility { get; set; }
        public string StudyUniqueId { get; set; }
    }
}
