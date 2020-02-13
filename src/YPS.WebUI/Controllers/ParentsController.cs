using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Parents.Commands.CreateParent;

namespace YPS.WebUI.Controllers
{
    public class ParentsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateParentCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}