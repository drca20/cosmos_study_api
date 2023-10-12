using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos_Study.Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string Domain { get; }
        string SiteId { get; }
    }
}
