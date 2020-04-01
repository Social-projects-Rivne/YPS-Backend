using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.JournalColumns.Commands.CreateJournalColumn;
using YPS.Application.JournalColumns.Queries.GetJournalColumnsByDisciplineQuery;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class JournalColumnController : ApiController
    {
        [Authorize(Roles = "teacher, head-assistant")]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody]CreateJournalColumnCommand command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{classId}/{disciplineId}")]
        public async Task<ActionResult<List<JournalColumnVm>>> GetByDiscipline(long classId, long disciplineId)
        {
            return Ok(await Mediator.Send(new GetJournalColumnsByDisciplineQuery { ClassId = classId, DisciplineId = disciplineId }));
        }
    }
}