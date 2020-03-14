using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Lessons.Commands.CreateLesson;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class LessonsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody]CreateLessonCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}
