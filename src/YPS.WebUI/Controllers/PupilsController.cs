using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Pupils.Commands.AddPupil;
using YPS.Application.Pupils.Queries.GetPupilsBySchool;

namespace YPS.WebUI.Controllers
{
    public class PupilsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreatePupilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{schoolId}")]
        public async Task<ActionResult<List<PupilsBySchoolVm>>> GetAllPupils(long schoolId)
        {
            try
            {
                return Ok(await Mediator.Send(new GetPupilsBySchoolQuery {SchoolId = schoolId}));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
