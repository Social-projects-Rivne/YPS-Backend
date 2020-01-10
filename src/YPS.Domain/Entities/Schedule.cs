using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Schedule
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Lesson")]
        public long LessonId { get; set; }
        [ForeignKey("Day")]
        public long DayId { get; set; }
        public ushort LessonNumber { get; set; }
        public Lesson Lesson { get; set; }
        public Day Day { get; set; }

    }
}
