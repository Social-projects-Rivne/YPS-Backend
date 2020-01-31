using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Pupils.Commands.AddPupil;

namespace YPS.WebUI.Controllers
{
    public class PupilsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreatePupilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
