using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Parent 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)  , ForeignKey("User")]
        public long Id { get; set; }
        public string WorkInfo { get; set; }
        public virtual User User { get; set; }

    }
}
