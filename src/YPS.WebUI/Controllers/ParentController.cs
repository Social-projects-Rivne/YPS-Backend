using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Parents.Queries;
using YPS.Application.Parents.ViewModels;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParentController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<ParentViewModel>>> GetParents([FromQuery]GetParentsQuery command)
        {
            var vm = await Mediator.Send(command);
            return Ok(vm);
        }
    }
}