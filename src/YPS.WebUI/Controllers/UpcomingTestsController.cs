using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YPS.Application.UpcomingTests.Queries.GetUpcomingTestsByPupil;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class UpcomingTestsController : ApiController
    {
        [Authorize(Roles = "pupil")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingTestVm>>> GetUpcomingTestsByPupilAsync()
        {
            long pupilId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetUpcomingTestsByPupilQuery { PupilId = pupilId }));
        }
    }
}