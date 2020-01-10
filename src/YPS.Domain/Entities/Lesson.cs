using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Lesson
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("TeacherToDiscipline")]
        public long TeacherToDisciplineId { get; set; }
        public  TeacherToDiscipline TeacherToDiscipline { get; set; }
        
    }
}
