﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Models;
using YPS.Application.Parents.Commands.CreateParent;
using YPS.Application.Parents.Queries.GetPupilsInfoByParent;
using YPS.Application.Parents.Queries.GetPupilAsParent;
using YPS.Application.Parents.Queries.GetParentProfileInfo;
using YPS.Application.Parents.Queries.GetParentsBySchool;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class ParentsController : ApiController
    {
        [HttpGet]
        [Authorize(Roles = "head-master,master")]
        public async Task<ActionResult<ICollection<ParentBySchoolVm>>> GetParentsBySchool()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetParentsBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "parent")]
        public async Task<ActionResult<GetParentProfileInfoVm>> GetParentProfileInfo()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetParentsProfileInfoQuery { Id = id }));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "parent")]
        public async Task<ActionResult<ICollection<GetPupilsInfoByParentVm>>> GetPupilsInfoByParent()
        {
            long parentId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetPupilsInfoByParentQuery { Id = parentId, SchoolId = schoolId }));
        }

        [HttpGet("[action]/{id}")]
        [Authorize(Roles = "parent")]
        public async Task<ActionResult<GetPupilAsParentVm>> GetPupilAsParent(long id)
        {
            return Ok(await Mediator.Send(new GetPupilAsParentQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<CreatedResponse>> Create([FromBody] CreateParentCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            command.SchoolId = schoolId;
            return Ok(await Mediator.Send(command));
        }
    }
}