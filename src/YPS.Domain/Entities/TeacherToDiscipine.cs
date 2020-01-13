using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;

namespace YPS.Domain.Entities
{
    public class TeacherToDiscipline
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Discipline")]
        public long DisciplineId { get; set; }

        [ForeignKey("Teacher")]
        public long TeacherId { get; set; }

        public virtual Discipline Discipline { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Lesson> Lessons { get; set; }

    }
}
