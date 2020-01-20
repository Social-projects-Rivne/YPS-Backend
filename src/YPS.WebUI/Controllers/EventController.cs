using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Event.Query.GetAllEvents;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<ActionResult<EventListViewModel>> GetAllEvents()
        {

            return Ok(await Mediator.Send(new GetAllEventsQuery(long.Parse(User.FindFirst(ClaimTypes.GivenName).Value))).ConfigureAwait(false));
        }    
    }

}