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
        public ushort LessonNumber { get; set; }

        public JournalColumn JournalColumn { get; set; }

        public long DayId { get; set; }
        public Day Day { get; set; }

        public long TeacherToDisciplineId { get; set; }
        public TeacherToDiscipline TeacherToDiscipline { get; set; }
    }
}
