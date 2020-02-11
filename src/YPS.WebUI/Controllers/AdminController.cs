using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Admins.Queries.GetAdmin;
using YPS.Application.Exceptions;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class AdminController : ApiController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize]
        public async Task<ActionResult> Admin()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier", StringComparison.InvariantCultureIgnoreCase));
            if (claim != null)
            {
                var viewModel = await Mediator.Send(new GetAdminQuery { Id = long.Parse(claim.Value) });
                return Ok(viewModel);
            }
            return BadRequest($"Unatorized {claim.Value}");
        }
    }
}