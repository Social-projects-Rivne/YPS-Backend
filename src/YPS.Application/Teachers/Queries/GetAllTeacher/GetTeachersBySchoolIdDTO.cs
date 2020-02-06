using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Teachers.Queries.GetTeacher
{
    class GetTeachersBySchoolIdDTO : IMapFrom<Teacher>
    {
        public long UserId { get; set; }
        public User User { get; set; }
        public string Degree { get; set; }
    }
}
