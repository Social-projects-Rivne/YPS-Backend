using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.SchoolRequests.Command;
using YPS.Application.Teachers.Queries.GetTeacher;
using YPS.Application.SchoolRequests.ViewModel;

namespace YPS.WebUI.Controllers
{
    public class TeachersController : ApiController
    {
        [HttpGet("{schoolId}")]
        public async Task<ActionResult<List<TeachersBySchoolVm>>> GetTeachers(long schoolId)
        {
            try
            {
                return Ok(await Mediator.Send(new TeachersBySchoolIdQuery { SchoolId = schoolId }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
 }
