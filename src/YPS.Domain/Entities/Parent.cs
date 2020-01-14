using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{    
    public class Parent 
    {
        [Key, ForeignKey("User"),Column(Order = 0)]
        public long Id { get; set; }
        public string WorkInfo { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ParentToPupil> ParentToPupils { get; set; }
    }
}
