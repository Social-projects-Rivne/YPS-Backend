using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Mark
    {
        [Key]
        public long Id { get; set; }
        public string Value { get; set; }
        
        [ForeignKey("JournalColumn")]
        public long JournalColumnId { get; set; }
        
        [ForeignKey("MarkType")]
        public long MarkTypeId { get; set; }
        
        [ForeignKey("Pupil")]
        public long PupilId { get; set; }

        public virtual JournalColumn JournalColumn { get; set; }
        public virtual MarkType MarkType { get; set; }
        public virtual Pupil Pupil { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
