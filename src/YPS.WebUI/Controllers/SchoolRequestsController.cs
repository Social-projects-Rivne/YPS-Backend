using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.SchoolRequests.Commands.ApproveSchoolRequest;
using YPS.Application.SchoolRequests.Commands.CreateSchoolRequest;
using YPS.Application.SchoolRequests.Commands.DisapproveSchoolRequest;
using YPS.Application.SchoolRequests.Queries.GetUnviewedSchoolRequests;

namespace YPS.WebUI.Controllers
{
    public class SchoolRequestsController : ApiController
    {
        [HttpPost("[action]")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<SchoolViewModel>> Approve([FromBody] ApproveSchoolRequestCommand command)
        {
            var response = await this.Mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<RemoveRequestViewModel>> Disapprove([FromQuery] DisapproveSchoolRequestCommand command)
        {
            var response = await this.Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<ICollection<SchoolRequestVm>>> GetSchoolRequests()
        {
            var vm = await this.Mediator.Send(new GetUnviewedSchoolRequestsQuery());
            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<long>> Create([FromBody] CreateSchoolRequestCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var account = await Mediator.Send(command).ConfigureAwait(false);
                return Ok(account);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
