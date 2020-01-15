using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Pupil
    {
        public Pupil()
        {
            ParentToPupils = new HashSet<ParentToPupil>();
            Marks = new HashSet<Mark>();
        }
        [Key]
        public long Id { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }

        [ForeignKey("ClassOf")]
        public long ClassId { get; set; }

        public virtual Class ClassOf { get; set; }
        public virtual User /*UserOf*/User { get; set; }
        public virtual ICollection<ParentToPupil> ParentToPupils { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
