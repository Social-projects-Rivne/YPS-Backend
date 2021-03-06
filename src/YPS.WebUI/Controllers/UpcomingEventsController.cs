﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Interfaces;
using YPS.Application.UpcomingEvents.Commands.CreateUpcomingEventByHeadAssistant;
using YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsByPupil;
using YPS.Application.UpcomingEvents.Queries.GetUpcomingEventsBySchool;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class UpcomingEventsController : ApiController
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingEventByPupilVm>>> GetUpcomingEventsBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetUpcomingEventsBySchoolQuery { SchoolId = schoolId }));
        }

        [Authorize(Roles = "head-assistant")]
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateUpcomingEventByHeadAssistantCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            command.SchoolId = schoolId;
            command.TeacherId = teacherId;
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles ="pupil")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<UpcomingEventByPupilVm>>> GetUpcomingEventsByPupil()
        {   
            long pupilId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetUpcomingEventsByPupilQuery { SchoolId = schoolId, PupilId = pupilId }));
        }
    }
}