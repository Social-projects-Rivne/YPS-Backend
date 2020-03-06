using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Lesson : EntityBase
    {
        public Lesson()
        {
            JournalColumns = new HashSet<JournalColumn>();
            Schedules = new HashSet<Schedule>();
        }
        public long AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }

        public long TeacherToDisciplineId { get; set; }
        public TeacherToDiscipline TeacherToDiscipline { get; set; }

        public ICollection<JournalColumn> JournalColumns { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
    }
}
