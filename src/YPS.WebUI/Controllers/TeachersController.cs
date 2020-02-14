using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.SchoolRequests.ViewModel;
using YPS.Application.Teachers.Commands.CreateTeacher;
using YPS.Application.Teachers.Queries.GetTeachersBySchool;

namespace YPS.WebUI.Controllers
{
    public class TeachersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateTeacherCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("{schoolId}")]
        public async Task<ActionResult<List<TeacherBySchoolVm>>> GetTeachers(long schoolId)
        {
            return Ok(await Mediator.Send(new GetTeachersBySchoolQuery { SchoolId = schoolId }));
        }
    }
 }
