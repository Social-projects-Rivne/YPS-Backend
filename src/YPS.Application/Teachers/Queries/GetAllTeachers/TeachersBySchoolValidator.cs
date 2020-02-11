using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using YPS.Application.Teachers.Queries.GetTeacher;
using MediatR;

namespace YPS.Application.Teachers.Queries.GetAllTeachers
{
    class TeachersBySchoolValidator : AbstractValidator<TeachersBySchoolVm>
    {
        public TeachersBySchoolValidator()
        {
            RuleFor(v => v.ClassName).Null().WithMessage("Don't have any");
        }
    }
}
