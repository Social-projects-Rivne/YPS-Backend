using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Homework :EntityBase
    {

        public Homework()
        {
            JournalColumns = new HashSet<JournalColumn>();
        }
        public string Title { get; set; }

       
        public long MarkId { get; set; }

        public virtual Mark Mark { get; set; }
        public  ICollection<JournalColumn> JournalColumns { get; set; }
    }
}
