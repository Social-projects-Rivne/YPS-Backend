using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Schedule
    {
        [Key]
        public long Id { get; set; }

        public ushort LessonNumber { get; set; }

        [ForeignKey("Lesson"), Column(Order = 0)]
        public long LessonId { get; set; }

        [ForeignKey("Day"), Column(Order = 1)]
        public long DayId { get; set; }


        public virtual Lesson Lesson { get; set; }
        public virtual Day Day { get; set; }

    }
}
