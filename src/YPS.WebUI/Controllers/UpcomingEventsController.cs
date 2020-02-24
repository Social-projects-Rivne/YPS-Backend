﻿using System;
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
        [HttpGet]
        public async Task<ActionResult<List<UpcomingEventVm>>> GetUpcomingEventsBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetUpcomingEventsBySchoolQuery { SchoolId = schoolId }));
        }
    }
}