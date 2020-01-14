using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Pupil
    {
        [Key,ForeignKey("User"),Column(Order = 0)]
        public long UserId { get; set; }

        [Key,ForeignKey("ClassOf"),Column(Order = 1)]
        public long ClassId { get; set; }

        public virtual Class ClassOf { get; set; }
        public virtual User /*UserOf*/User { get; set; }
        public virtual ICollection<ParentToPupil> ParentToPupils { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
