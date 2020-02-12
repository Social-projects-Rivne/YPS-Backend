﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YPS.Application.Pupils.Commands.CreatePupil;
using YPS.Application.Pupils.Queries.GetPupilsByClass;
using YPS.Application.Pupils.Queries.GetPupilsBySchool;

namespace YPS.WebUI.Controllers
{
    public class PupilsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreatePupilCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet("[action]/{schoolId}")]
        public async Task<ActionResult<List<PupilBySchoolVm>>> GetBySchool(long schoolId)
        {
            return Ok(await Mediator.Send(new GetPupilsBySchoolQuery { SchoolId = schoolId }));
        }

        [HttpGet("[action]/{classId}")]
        public async Task<ActionResult<List<PupilByClassVm>>> GetByClass(long classId)
        {
            return Ok(await Mediator.Send(new GetPupilsByClassQuery { ClassId = classId }));
        }
    }
}
