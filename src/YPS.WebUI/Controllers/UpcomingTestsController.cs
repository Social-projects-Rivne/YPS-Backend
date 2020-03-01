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
        public async Task<ActionResult<List<UpcomingTestVm>>> GetUpcomingTestsByPupilAsync()
        {
            long PupilId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetUpcomingTestsByPupilQuery { PupilId = PupilId }));
        }

        [Authorize(Roles = "teacher")]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateUpcomingTestCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingTestVm>>> GetUpcomingTestsByTeacherAsync()
        {
            long TeacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetUpcomingTestsByTeacherQuery { TeacherId = TeacherId }));
        }
    }
}