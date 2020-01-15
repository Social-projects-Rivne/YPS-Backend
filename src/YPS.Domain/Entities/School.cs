using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class School : EntityBase
    {
        public School()
        {
            Teachers = new HashSet<Teacher>();
             UpcomingEvents = new HashSet<UpcomingEvent>();
        }
        public string Name { get; set; }
        public string ShortName { get; set; }

        public  ICollection<Teacher> Teachers { get; set; }
        public  ICollection<UpcomingEvent> UpcomingEvents { get; set; }
    }
}
