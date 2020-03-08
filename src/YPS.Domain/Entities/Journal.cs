using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Journal : EntityBase
    {
        public Journal()
        {
            JournalColumns = new HashSet<JournalColumn>();
        }

        public long ClassId { get; set; }
        public Class Class { get; set; }

        public ICollection<JournalColumn> JournalColumns { get; set; }
    }
}
