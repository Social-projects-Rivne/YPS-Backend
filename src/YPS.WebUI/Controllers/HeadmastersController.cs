using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Auth.Command.CreateHeadMaster;
using YPS.Application.Models;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class HeadmastersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateHeadMaster([FromBody] CreateHeadMasterCommand request)
        {
            return Ok(await Mediator.Send(request));
        }
    }
}
