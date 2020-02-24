﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Auth.Command.CreateHeadMaster;
using YPS.Application.Models;
using YPS.Application.SchoolRequests.Commands.GetMasterRegisterLink;

namespace YPS.WebUI.Controllers
{   
    public class HeadmastersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CreateHeadMaster([FromBody] CreateHeadMasterCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpPost("action")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> CheckMaster([FromQuery] CheckMasterLinkCommand command)
        {
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}
