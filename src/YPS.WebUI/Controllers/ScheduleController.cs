using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Schedule.Queries.GetScheduleForTeacher;

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
    }
}