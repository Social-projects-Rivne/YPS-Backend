using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Discipline
    {
        [Key]
        public long Id { get; set; }

        public  string Name { get; set; }

        public virtual ICollection<UpcomingTest> UpcomingTests { get; set; }
        public virtual ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
    }
}
