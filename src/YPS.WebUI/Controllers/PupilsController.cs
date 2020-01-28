using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Pupils.Commands.AddPupil;
using YPS.Application.Pupils.ViewModels;

namespace YPS.WebUI.Controllers
{
    public class PupilsController : BaseController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreatePupilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
