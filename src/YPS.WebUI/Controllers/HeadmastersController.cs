using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Headmasters.Commands.CreateHeadmaster;
using YPS.Application.HeadMasters.Queries.CheckMasterRegisterLink;
using YPS.Application.Models;
namespace YPS.WebUI.Controllers
{
    public class HeadmastersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreatedResponse>> CreateHeadMaster([FromBody] CreateHeadMasterCommand request)
        {
            return Ok(await Mediator.Send(request));
        }

        [HttpGet("{link}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<bool>> CheckMasterRegisterLink(string link)
        {
            bool response = await Mediator.Send(new CheckHeadMasterRegisterLinkQuery { Link = link });

            if (!response)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
