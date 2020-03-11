using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Schedule.Queries.GetScheduleForTeacher;
using YPS.Application.Schedule.Query.GetScheduleByClass;

namespace YPS.WebUI.Controllers
{
    public class ScheduleController : ApiController
    {
        [Authorize(Roles = "teacher")]
        [HttpGet]
        public async Task<ActionResult> GetForTeacher()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetScheduleForTeacherQuery { Id = id }));
        }

        [Authorize]
        [HttpGet("[action]/{classId}")]
        public async Task<ActionResult<ICollection<GetScheduleByClassVm>>> GetLessonsByClass(long classId)
        {
            var vm = await Mediator.Send(new GetScheduleByClassQuery
            {
                ClassId = classId
            });
            return Ok(vm);
        }
    }
}