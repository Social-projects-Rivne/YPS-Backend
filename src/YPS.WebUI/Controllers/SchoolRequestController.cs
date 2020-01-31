using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.SchoolRequest.Command.Register;

namespace YPS.WebUI.Controllers
{

    public class SchoolRequestController : ApiController
    {
        

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> Create([FromBody] RegisterSchoolCommand command)
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