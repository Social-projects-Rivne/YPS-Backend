using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YPS.Application.UpcomingTests.Commands.CreateUpcomingTest;
using YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByPupil;
using YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByTeacher;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class UpcomingTestsController : ApiController
    {
        [Authorize(Roles = "pupil")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingTestVm>>> GetByPupil()
        {
            long pupilId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetUpcomingTestsByPupilQuery { PupilId = pupilId }));
        }

        [Authorize(Roles = "teacher")]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateUpcomingTestCommand command)
        {
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            command.TeacherId = teacherId;

            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingTestVm>>> GetByTeacher()
        {
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetUpcomingTestsByTeacherQuery { TeacherId = teacherId }));
        }
    }
}