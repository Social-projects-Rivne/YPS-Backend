using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YPS.Application.Interfaces;

namespace YPS.WebUI.Services
{
    public class CurrentUserInformationService : ICurrentUserInformationService
    {
        public long UserId { get; }
        public long SchoolId { get; }

        public CurrentUserInformationService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = long.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            SchoolId = long.Parse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName));
        }
    }
}
