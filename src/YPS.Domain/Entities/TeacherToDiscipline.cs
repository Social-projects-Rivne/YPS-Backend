using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class TeacherToDiscipline : EntityBase
    {
        public TeacherToDiscipline()
        {
            Lessons = new HashSet<Lesson>();
        }

        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
