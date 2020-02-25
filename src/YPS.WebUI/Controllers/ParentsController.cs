﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Models;
using YPS.Application.Parents.Commands.CreateParent;
using YPS.Application.Parents.Queries;
using YPS.Application.Parents.Queries.GetParentsBySchool;
using YPS.Application.Parents.ViewModels;
using YPS.Application.Parents.ViewModels.GetParentsBySchool;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class ParentsController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<ParentBySchoolVm>>> GetParentsBySchool()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", StringComparison.InvariantCultureIgnoreCase));
            if (claim != null)
            {
                var viewModel = await Mediator.Send(new GetParentsBySchoolQuery { SchoolId = long.Parse(claim.Value) });
                return Ok(viewModel);
            }
            return BadRequest($"Unatorized");
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "parent")]
        public async Task<ActionResult<GetParentProfileInfoVm>> GetParentProfileInfo()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetParentProfileInfoQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateParentCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            command.SchoolId = schoolId;
            return Ok(await Mediator.Send(command));
        }
    }
}