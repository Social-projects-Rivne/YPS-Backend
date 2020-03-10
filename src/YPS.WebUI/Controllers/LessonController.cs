using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Lessons.Query.GetLessonsByClass;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ApiController
    {
        [HttpGet("[action]/{classId}")]
        public async Task<ActionResult<ICollection<GetLessonsByClassVm>>> GetLessonsByClass(long classId)
        {
            var vm = await Mediator.Send(new GetLessonsByClassQuery
            {
                ClassId = classId
            });
            return Ok(vm);
        }
    }
}