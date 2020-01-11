using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Pupil
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity) , ForeignKey("User")]
        public long Id { get; set; }

        [ForeignKey("Class")]
        public long ClassId { get; set; }
        public Class Class { get; set; }
        public virtual User User { get; set; }

       
    }
}
