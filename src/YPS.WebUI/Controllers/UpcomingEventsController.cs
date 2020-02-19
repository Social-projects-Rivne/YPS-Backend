using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Interfaces;
using YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsBySchool;

namespace YPS.WebUI.Controllers
{    
    [Authorize]
    public class UpcomingEventsController : ApiController
    {
        private readonly ICurrentUserInformationService _currService;

        public UpcomingEventsController(ICurrentUserInformationService currService)
        {
            _currService = currService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UpcomingEventVm>>> GetAllUpcomingEvents()
        {
            long schoolId = _currService.SchoolId;
            try
            {
                return Ok(await Mediator.Send(new GetUpcomingEventsBySchoolQuery { SchoolId = schoolId }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}