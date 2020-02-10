using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Pupils.Query.GetAllPupils;
using YPS.Application.Pupils.Commands.AddPupil;
using YPS.Application.Pupils.Queries.GetAllPupils;

namespace YPS.WebUI.Controllers
{
    public class PupilsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreatePupilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<List<PupilVm>>> GetAllPupils()
        {
            try
            {
                return Ok(await Mediator.Send(new GetPupilsBySchoolQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
