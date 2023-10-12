using Cosmos_Study.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Cosmos_Study.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            Domain = httpContextAccessor.HttpContext?.Request.Headers["Origin"];
            SiteId = httpContextAccessor.HttpContext?.Request.Query["EmbeddedId"];
        }

        public string UserId { get; }
        public string Domain { get; }
        public string SiteId { get; }
    }
}
