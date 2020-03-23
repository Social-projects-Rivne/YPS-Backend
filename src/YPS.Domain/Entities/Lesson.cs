using System;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Lesson : EntityBase
    {
        public ushort LessonNumber { get; set; }
        public DateTime LessonDate { get; set; }
        public string LessonTimeGap { get; set; }

        public JournalColumn JournalColumn { get; set; }
        
        public long AuditoriumId { get; set; }
        public Auditorium Auditorium { get; set; }

        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public long ClassId { get; set; }
        public Class Class { get; set; }
    }
}
