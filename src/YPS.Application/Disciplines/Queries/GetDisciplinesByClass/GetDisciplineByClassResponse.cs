using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Disciplines.Queries.GetDisciplinesByClass
{
    public class GetDisciplineByClassResponse
    {
        public List<DisciplineByClassVm> Disciplines { get; set; }
        public bool IsClassTeacher { get; set; }
    }
}
