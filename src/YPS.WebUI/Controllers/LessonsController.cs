using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Lessons.Commands.CreateLesson;
using YPS.Application.Lessons.Queries.GetLessonsByTeacher;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class LessonsController : ApiController
    {
        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<LessonByTeacherDto>>> GetLessonsByTeacherId()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetLessonsByTeacherQuery { TeacherId = userId }));
        }

        [Authorize(Roles = "head-assistant")]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody]CreateLessonCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
