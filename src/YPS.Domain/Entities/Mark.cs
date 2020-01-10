using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Mark
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("JournalColumn")]
        public long JournalColumnId { get; set; }
        [ForeignKey("MarkType")]
        public long MarkTypeId { get; set; }

        public string Value { get; set; }
        [ForeignKey("Pupil")]
        public long PupilId { get; set; }

        public JournalColumn JournalColumn { get; set; }
        public MarkType MarkType { get; set; }
        public Pupil Pupil { get; set; }



    }
}
