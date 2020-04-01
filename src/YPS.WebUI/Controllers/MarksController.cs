using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YPS.Application.Models;
using YPS.Application.Marks.Queries.GetMarksByPupil;
using MediatR;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class MarksController : ApiController
    {
        [Authorize(Roles = "pupil")]
        [HttpGet("{disciplineId}")]
        public async Task<ActionResult<List<MarkByPupilDto>>> GetForPupilByDiscipline(long disciplineId)
        {
            long pupilid = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetMarksByPupilQuery { PupilId = pupilid, DisciplineId = disciplineId }));
        }

        [Authorize(Roles = "parent")]
        [HttpGet("{disciplineId}/{pupilId}")]
        public async Task<ActionResult<List<MarkByPupilDto>>> GetPupilMarksFromParentByDiscipline(long pupilId, long disciplineId)
        {
            return Ok(await Mediator.Send(new GetMarksByPupilQuery { PupilId = pupilId, DisciplineId = disciplineId }));
        }
    }
}
