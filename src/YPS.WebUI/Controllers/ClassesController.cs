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
using YPS.Application.Classes.Commands.CreateClass;
using YPS.Application.Models;
using YPS.Application.Classes.Queries.GetClassByNumber;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles = "head-master, master, teacher, head-assistant")]
    public class ClassesController : ApiController
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<List<ClassBySchoolVm>>> GetBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetClassesBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpPost]
        public async Task<ActionResult<CreatedResponse>> Create([FromBody] CreateClassCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<ClassWithFullInfoVm>>> GetBySchoolWithFullInfo()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetClassesBySchoolWithFullInfoQuery { SchoolId = schoolId }));
        }

        [HttpGet("[action]/{number}")]
        [Authorize]
        public async Task<ActionResult<ICollection<GetClassByNumberVm>>> GetClassesByNumber(int number)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetClassByNumberQuery {
                Number = number,
                SchoolId = schoolId
            }));
        }
    }
}
