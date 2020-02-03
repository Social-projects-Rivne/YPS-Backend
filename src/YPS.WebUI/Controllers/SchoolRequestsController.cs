using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.SchoolRequests.Commands.CreateSchoolRequest;

namespace YPS.WebUI.Controllers
{
    public class SchoolRequestsController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> Create([FromBody] CreateSchoolRequestCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var account = await Mediator.Send(command).ConfigureAwait(false);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
