using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Disciplines.Queries.GetAllDiscipline;
using YPS.Application.Disciplines.Queries.GetDisciplinesByClass;
using YPS.Application.Disciplines.Queries.GetDisciplinesByTeacher;

namespace YPS.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ApiController
    {
        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<DisciplineBySchoolVm>>> GetDisciplinesByTeacherAsync()
        {
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetDisciplinesByTeacherQuery { TeacherId = teacherId }));
        }

        [Authorize(Roles = "head-assistant, pupil, parent")]
        [HttpGet("[action]")]
        public async Task<ActionResult<List<DisciplineBySchoolVm>>> GetAllDisciplinesBySchoolAsync()
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            return Ok(await Mediator.Send(new GetAllDisciplinesBySchoolQuery { SchoolId = schoolId }));
        }

        [Authorize(Roles = "teacher")]
        [HttpGet("[action]")]
        public async Task<ActionResult<GetDisciplineByClassResponse>> GetByClass()
        {
            long teacherId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            return Ok(await Mediator.Send(new GetDisciplinesByClassQuery { TeacherId = teacherId }));
        }
    }
}