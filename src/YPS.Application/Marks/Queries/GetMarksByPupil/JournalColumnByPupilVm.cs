using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Marks.Queries.GetMarksByPupil
{
    public class JournalColumnByPupilVm
    {
        public string LessonDate { get; set; }
        public string Discipline { get; set; }
        public string Topic { get; set; }
        public List<MarkByPupilDto> Marks { get; set; }
    }
}
