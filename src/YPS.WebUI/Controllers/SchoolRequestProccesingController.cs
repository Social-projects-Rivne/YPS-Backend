using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using YPS.Application.SchoolRequests.Commands.ApproveSchoolRequest;
using YPS.Application.SchoolRequests.Commands.DisapproveSchoolRequest;
using YPS.Application.SchoolRequests.Queries.GetUnviewedSchoolRequests;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class SchoolRequestProccesingController : ApiController
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]       
        public async Task<ActionResult<SchoolViewModel>> Approve([FromBody] ApproveSchoolRequestCommand command)
        {
            var response = await this.Mediator.Send(command);
            return Ok(response);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<RemoveRequestViewModel>> Disapprove([FromQuery] DisapproveSchoolRequestCommand command)
        {
            var response = await this.Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ICollection<SchoolRequestVm>>> GetSchoolRequests([FromQuery]GetUnviewedSchoolRequestsQuery command)
        {
            var vm = await this.Mediator.Send(command);
            return Ok(vm);
        }
    }
}