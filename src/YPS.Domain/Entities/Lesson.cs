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

        public long TeacherToDisciplineId { get; set; }
        public virtual TeacherToDiscipline TeacherToDiscipline { get; set; }

        public  ICollection<JournalColumn> JournalColumns { get; set; }
        public  ICollection<Schedule> Schedules { get; set; }
    }
}
