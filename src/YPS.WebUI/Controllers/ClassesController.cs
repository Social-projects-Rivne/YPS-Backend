using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Classes.Queries.GetClassesBySchool;

namespace YPS.WebUI.Controllers
{
    public class ClassesController : ApiController
    {
        [HttpGet("{schoolId}")]
        public async Task<ActionResult<List<ClassBySchoolVm>>> GetBySchool(long schoolId)
        {
            return Ok(await Mediator.Send(new GetClassesBySchoolQuery { SchoolId = schoolId }));
        }
    }
}