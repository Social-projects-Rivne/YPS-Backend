using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Auditoriums.Queries.GetAvailableAuditoriums;
using YPS.Application.Models;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class AuditoriumsController : ApiController
    {
        [HttpGet("{lessonDate}/{lessonNumber}")]
        public async Task<ActionResult<List<AvailableAuditoriumVm>>> GetAvailableAuditoriums(DateTime lessonDate, ushort lessonNumber)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetAvailableAuditoriumsQuery { SchoolId = schoolId, LessonDate = lessonDate, LessonNumber = lessonNumber }));
        }
    }
}
