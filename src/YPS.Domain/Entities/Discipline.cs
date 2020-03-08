using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Discipline : EntityBase
    {
        public Discipline()
        {
            UpcomingTests = new HashSet<UpcomingTest>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
            Lessons = new HashSet<Lesson>();
        }

        public string Name { get; set; }

        public ICollection<UpcomingTest> UpcomingTests { get; set; }
        public ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
