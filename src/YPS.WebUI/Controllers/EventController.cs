using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Event.Query.GetAllEvents;
using YPS.Application.Interfaces;
//using YPS.Application.Event.Query.GetAllEvents;

namespace YPS.WebUI.Controllers
{    
    //[Authorize]
    public class EventController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<UpcomingEventVm>>> GetAllUpcomingEvents()
        {            
            try
            {
                return Ok(await Mediator.Send(new GetAllUpcomingEventsQuery()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}