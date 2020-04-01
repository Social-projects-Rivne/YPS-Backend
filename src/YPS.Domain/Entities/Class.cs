using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Class : EntityBase
    {
        public Class()
        {
            UpcomingEvents = new HashSet<UpcomingEvent>();
            UpcomingTests = new HashSet<UpcomingTest>();
            Lessons = new HashSet<Lesson>();
            ClassToPupils = new HashSet<ClassToPupil>();
            ClassToDisciplines = new HashSet<ClassToDiscipline>();
        }

        public long Number { get; set; }
        public string Character { get; set; }

        public long ClassTeacherId { get; set; }
        public Teacher TeacherOf { get; set; }

        public int YearFrom { get; set; }
        public int YearTo { get; set; }

        public Journal Journal { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
        public ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public ICollection<UpcomingTest> UpcomingTests { get; set; }
        public ICollection<ClassToPupil> ClassToPupils { get; set; }
        public ICollection<ClassToDiscipline> ClassToDisciplines { get; set; }
    }
}
