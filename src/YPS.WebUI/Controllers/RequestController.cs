using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.SchoolRequests.ViewModel;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : BaseController
    {
        public async Task<ActionResult<SchoolRequetsViewModel>> Approve([FromBody] ApproveCommand command)
        {
            return await this.Mediator.Send(command);
        }
    }
}