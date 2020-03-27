using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Schools.Queries.GetSchoolById;

namespace YPS.WebUI.Controllers
{
    public class SchoolsController : ApiController
    {
        [Authorize]
        public async Task<ActionResult<SchoolVm>> GetById()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetSchoolByIdQuery { SchoolId = schoolId }));
        }
    }
}