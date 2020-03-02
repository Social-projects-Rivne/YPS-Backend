using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using YPS.Application.Models;
using YPS.Application.Pupils.Commands.CreatePupil;
using YPS.Application.Pupils.Queries.GetPupilsByClass;
using YPS.Application.Pupils.Queries.GetPupilsById;
using YPS.Application.Pupils.Queries.GetPupilsBySchool;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class PupilsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreatedResponse>> Create([FromBody] CreatePupilCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            command.SchoolId = schoolId;
            return Ok(await Mediator.Send(command));
        }
        [Authorize(Roles = "pupil")]
        [HttpGet("[action]")]
        public async Task<ActionResult<PupilByIdVm>> GetPupilById()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetPupilByIdQuery { Id = id }));
        }

        [Authorize(Roles = "head-master, master")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<PupilBySchoolVm>>> GetBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetPupilsBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpGet("[action]/{classId}")]
        public async Task<ActionResult<List<PupilByClassVm>>> GetByClass(long classId)
        {
            return Ok(await Mediator.Send(new GetPupilsByClassQuery { ClassId = classId }));
        }
    }
}
