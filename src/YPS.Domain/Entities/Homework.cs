using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Homework
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("Mark")]
        public long MarkId { get; set; }

        public virtual Mark Mark { get; set; }
        public virtual ICollection<JournalColumn> JournalColumns { get; set; }
    }
}
