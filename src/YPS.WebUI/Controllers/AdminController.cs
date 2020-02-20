using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Admins.Queries.GetAdmin;
using YPS.Application.Exceptions;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Admin()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetAdminQuery { Id = userId }));
        }
    }
}