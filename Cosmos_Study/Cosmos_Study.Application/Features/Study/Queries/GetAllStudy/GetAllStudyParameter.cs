using Cosmos_Study.Application.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmos_Study.Application.Features.Study.Queries.GetAllStudy
{
    public class GetAllStudyParameter : RequestParameter
    {
        public string EmbeddedId { get; set; }
    }
}
