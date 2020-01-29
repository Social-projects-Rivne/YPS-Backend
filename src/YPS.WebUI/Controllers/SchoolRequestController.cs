using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.SchoolRequests.Queries;
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
            var response = await this.Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RemoveRequestViewModel>> Disapprove([FromBody] DisapproveCommand command)
        {

            var response = await this.Mediator.Send(command);
            return Ok(response);

        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ICollection<SchoolRequestViewModel>>> GetSchoolRequests([FromQuery]GetRequestsQuery command)
        {
            var vm = await this.Mediator.Send(command);
            return Ok(vm);
        }
    }
}