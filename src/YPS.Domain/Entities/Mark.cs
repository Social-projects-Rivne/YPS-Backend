using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Mark : EntityBase
    {
        public string Value { get; set; }

        public long JournalColumnId { get; set; }
        public JournalColumn JournalColumn { get; set; }

        public long MarkTypeId { get; set; }
        public virtual MarkType MarkType { get; set; }

        public long PupilId { get; set; }
        public Pupil Pupil { get; set; }

        public long? HomeworkId { get; set; }    
        public Homework Homework { get; set; }
    }
}
