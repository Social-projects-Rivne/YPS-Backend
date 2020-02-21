using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Classes.Queries.GetClassesBySchool;
using YPS.Application.Classes.Queries.GetClassesBySchoolWithFullInfo;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles = "head-master, master")]
    public class ClassesController : ApiController
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<List<ClassBySchoolVm>>> GetBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetClassesBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<ClassWithFullInfoVm>>> GetBySchoolWithFullInfo()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetClassesBySchoolWithFullInfoQuery { SchoolId = schoolId }));
        }
    }

}