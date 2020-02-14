using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Auth.Command.CreateHeadMaster;


namespace YPS.WebUI.Controllers
{
    //[Authorize]
    public class HeadmastersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult> CreateHeadMaster([FromBody] CreateHeadMasterCommand request)
        {
            try { 
            var user = await Mediator.Send(request).ConfigureAwait(false);
            return Ok(user);
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
