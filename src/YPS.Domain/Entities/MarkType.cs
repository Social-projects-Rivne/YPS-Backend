using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class MarkType
    {
        [Key]
        public long Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
