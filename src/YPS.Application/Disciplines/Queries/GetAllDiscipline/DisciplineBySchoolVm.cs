using System;
using System.Collections.Generic;
using System.Text;
using YPS.Application.Mapping;
using YPS.Domain.Entities;

namespace YPS.Application.Disciplines.Queries.GetAllDiscipline
{
    public class DisciplineBySchoolVm : IMapFrom<Discipline>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
