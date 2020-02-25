using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YPS.Application.Classes.Queries.GetClassesBySchool;
using YPS.Application.Classes.Commands.CreateClass;

namespace YPS.WebUI.Controllers
{
    public class ClassesController : ApiController
    {
        [HttpGet("[action]/{schoolId}")]
        public async Task<ActionResult<List<ClassBySchoolVm>>> GetBySchool(long schoolId)
        {
            return Ok(await Mediator.Send(new GetClassesBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateClassRequestCommand command)
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
