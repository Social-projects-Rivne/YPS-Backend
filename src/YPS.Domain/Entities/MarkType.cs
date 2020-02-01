using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class MarkType : EntityBase
    {
        public MarkType()
        {
            Marks = new HashSet<Mark>();
        }

        public string Type { get; set; }
        public string Description { get; set; }

        public ICollection<Mark> Marks { get; set; }
    }
}
