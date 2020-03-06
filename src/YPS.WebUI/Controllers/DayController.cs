using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Days.Queries.GetAllDays;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class DayController : ApiController
    {
        [HttpGet("[action]")]
        public async Task<ActionResult<List<DayViewModel>>> GetAllDays()
        {
            return Ok(await Mediator.Send(new GetAllDaysQuery()));
        }
    }
}