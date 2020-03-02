using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Application.Teachers.Commands.CreateTeacher;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using YPS.Application.Models;
using YPS.Application.Teachers.Queries.GetTeachersBySchool;
using System.Security.Claims;
using YPS.Application.Teachers.Queries.GetTeacher;
using YPS.Application.Teachers.Queries.GetMasterInfo;

namespace YPS.WebUI.Controllers
{
    [Authorize]
    public class TeachersController : ApiController
    {
        [Authorize(Roles = "head-master, master")]
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateTeacherCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            command.SchoolId = schoolId;
            return Ok(await Mediator.Send(command));
        }
        [Authorize(Roles = "head-master, master")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<TeacherBySchoolVm>>> GetTeachersBySchoolId()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetTeachersBySchoolQuery { SchoolId = schoolId }));
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "teacher")]
        public async Task<ActionResult<TeacherProfileInfoVM>> GetTeacherById()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetTeacherProfileInfoQuery { Id = userId }));
        }

        [HttpGet("[action]")]
        [Authorize(Roles = "master, head-master")]
        public async Task<ActionResult<TeacherProfileInfoVM>> GetMaster()
        {
            long id = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetMasterInfoQuery { Id = id }));
        }
        [HttpGet("[action]")]
        [Authorize(Roles = "head-assistant")]
        public async Task<ActionResult<TeacherProfileInfoVM>> GetHeadAssistantById()
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            return Ok(await Mediator.Send(new GetTeacherProfileInfoQuery { Id = userId }));
        }
    }
}