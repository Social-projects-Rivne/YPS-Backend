using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.SchoolRequests.ViewModel;

namespace YPS.WebUI.Controllers
{    
    public class SchoolRequestController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<SchoolViewModel>> Approve([FromBody] ApproveCommand command)
        {
            return await this.Mediator.Send(command);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RemoveRequestViewModel>> Disapprove([FromBody] DisapproveCommand command)
        {
            return await this.Mediator.Send(command);
        }
    }
}