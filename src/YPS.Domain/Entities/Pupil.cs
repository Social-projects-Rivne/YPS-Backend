using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Pupil : EntityBase
    {
        public Pupil()
        {
            ParentToPupils = new HashSet<ParentToPupil>();
            Marks = new HashSet<Mark>();
        }

        public long SchoolId { get; set; }

        public long UserId { get; set; }
        public virtual User User { get; set; }

        public long ClassId { get; set; }
        public virtual Class ClassOf { get; set; }
        
        public ICollection<ParentToPupil> ParentToPupils { get; set; }
        public ICollection<Mark> Marks { get; set; }
    }
}
