using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.Teachers.Queries.GetTeacher;
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Application.Teachers.Commands.CreateTeacher;
using Microsoft.AspNetCore.Authorization;
using MediatR;

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles = "head-master, master")]
    public class TeachersController : ApiController
    {
        private IRequest<object> command;

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateTeacherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //[HttpGet("{schoolId}")]
        [HttpGet("{schoolId}")]
        public async Task<ActionResult<List<TeacherBySchoolVm>>> GetTeachers(long schoolId)
        {
            //var vm = await Mediator.Send(command);
            //return Ok(vm);
            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", StringComparison.InvariantCultureIgnoreCase));
            if (claim != null)
            {
                var viewModel = await Mediator.Send(new GetTeachersBySchoolQuery { SchoolId = long.Parse(claim.Value) });
                return Ok(viewModel);
            }
            return BadRequest($"Unatorized");

            // return Ok(await Mediator.Send(new GetTeachersBySchoolQuery { SchoolId = schoolId }));
        }
    }
 }
