using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YPS.Application.Journals.Queries;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class JournalsController : ApiController
    {
        [HttpGet("{disciplineId}")]
        public async Task<ActionResult<JournalViewModel>> GetForPupilByDiscipline(long disciplineId)
        {
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetJournalByDisciplineQuery { TeacherId = teacherId, DisciplineId = disciplineId }));
        }
    }
}
