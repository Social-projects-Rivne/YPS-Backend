using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Lesson
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("TeacherToDiscipline")]
        public long TeacherToDisciplineId { get; set; }

        public virtual TeacherToDiscipline TeacherToDiscipline { get; set; }
        public virtual ICollection<JournalColumn> JournalColumns { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
