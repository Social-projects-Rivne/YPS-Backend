using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class UpcomingEvent : EntityBase
    {
        public long? ClassId { get; set; }

        public long SchoolId { get; set; }

        public DateTime TimeOfCerate { get; set; }

        public long TeacherId{ get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
        public School School { get; set; }
    }
}
