using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{    
    public class Parent 
    {
        [Key]
        public long Id { get; set; }
        public string WorkInfo { get; set; }

        [ForeignKey("UserOf")]
        public long UserId { get; set; }

        public virtual User UserOf { get; set; }
        public virtual ICollection<ParentToPupil> ParentToPupils { get; set; }
    }
}
