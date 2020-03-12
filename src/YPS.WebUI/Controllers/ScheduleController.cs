using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Schedule.Models;
using YPS.Application.Schedule.Queries.GetScheduleForPupil;
using YPS.Application.Schedule.Queries.GetScheduleForTeacher;
using YPS.Application.Schedule.Query.GetScheduleByClass;

namespace YPS.WebUI.Controllers
{
    public class ScheduleController : ApiController
    {
        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetForTeacher()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetScheduleForTeacherQuery { Id = id }));
        }

        [Authorize(Roles = "pupil")]
        [HttpGet("[action]")]
        public async Task<ActionResult> GetForPupil()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetScheduleForPupilQuery { Id = id }));
        }

        [Authorize]
        [HttpGet("[action]/{classId}")]
        public async Task<ActionResult<ICollection<ScheduleVm>>> GetScheduleByClass(long classId)
        {
            var vm = await Mediator.Send(new GetScheduleByClassQuery
            {
                ClassId = classId
            });
            return Ok(vm);
        }
    }
}