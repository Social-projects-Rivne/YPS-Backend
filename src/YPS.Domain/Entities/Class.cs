using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Class 
    {
        [Key]
        public long Id { get; set; }
        public long Number { get; set; }
        public string Character { get; set; }

        [ForeignKey("TeacherOf")]
        public long ClassTeacherId { get; set; }

        public virtual Teacher TeacherOf { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
    }
}
