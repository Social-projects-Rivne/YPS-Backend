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
        [HttpGet("{classId}/{disciplineId}")]
        public async Task<ActionResult<JournalViewModel>> GetForPupilByDiscipline(long classId, long disciplineId)
        {
            return Ok(await Mediator.Send(new GetJournalByDisciplineQuery {ClassId = classId, DisciplineId = disciplineId }));
        }
    }
}
