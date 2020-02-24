﻿using Microsoft.AspNetCore.Mvc;
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

namespace YPS.WebUI.Controllers
{
    [Authorize(Roles = "head-master, master")]
    public class TeachersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateTeacherCommand command)
        {
            long schoolId = long.Parse(User.FindFirstValue(ClaimTypes.GivenName));
            command.SchoolId = schoolId;
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<List<TeacherBySchoolVm>>> GetTeachers()
        {
            var claim = User.Claims.FirstOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname", StringComparison.InvariantCultureIgnoreCase));
            if (claim != null)
            {
                var viewModel = await Mediator.Send(new GetTeachersBySchoolQuery { SchoolId = long.Parse(claim.Value) });
                return Ok(viewModel);
            }
            return BadRequest($"Unatorized");
        }
    }
 }
