using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Lessons.Queries.GetLessonsByTeacher;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles ="teacher")]
    public class LessonsController : ApiController
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<List<LessonByTeacherDto>>> GetLessonsByTeacherId()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetLessonsByTeacherQuery { TeacherId = userId }));
        }
    }
}