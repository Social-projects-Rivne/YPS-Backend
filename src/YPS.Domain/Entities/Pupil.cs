using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Pupil
    {
        [Key, ForeignKey("User")]
        public long Id { get; set; }

        [ForeignKey("ClassOf")]
        public long ClassId { get; set; }

        //[ForeignKey("UserOf")]
        //public long UserId { get; set; }

        public virtual Class ClassOf { get; set; }
        public virtual User /*UserOf*/User { get; set; }

        public virtual ICollection<ParentToPupil> ParentToPupils { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
