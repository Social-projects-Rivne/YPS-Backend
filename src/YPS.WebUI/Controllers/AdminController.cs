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
    [Authorize("admin")]
    public class AdminController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Admin(long Id)
        {
            var viewModel = await Mediator.Send(new GetAdminQuery { Id=Id});
            return Ok(viewModel);
        }
           
    }
}