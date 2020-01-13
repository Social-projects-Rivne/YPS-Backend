using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class UpcomingEvent
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Class")]
        public long ClassId { get; set; }

        [ForeignKey("School")]
        public long SchoolId { get; set; }

        public virtual Class Class { get; set; }
        public virtual School School { get; set; }
    }
}
