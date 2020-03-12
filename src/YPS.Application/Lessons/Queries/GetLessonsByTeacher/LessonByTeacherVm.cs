using System;
using System.Collections.Generic;
using System.Text;

namespace YPS.Application.Lessons.Queries.GetLessonsByTeacher
{
    public class LessonByTeacherVm
    {
        public string DayName { get; set; }
        public string Date { get; set; }

        public List<LessonByTeacherDto> Lessons { get; set; }
    }
}
