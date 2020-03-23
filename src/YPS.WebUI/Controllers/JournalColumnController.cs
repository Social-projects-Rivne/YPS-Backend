using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Lessons.Commands.CreateJournalColumn;

namespace YPS.WebUI.Controllers
{
    //[Authorize]
    public class JournalColumnController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody]CreateJournalColumnCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }
    }
}