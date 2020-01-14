using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Class 
    {
        public Class()
        {
            Pupils = new HashSet<Pupil>();
            Journals = new HashSet<Journal>();
            UpcomingEvents = new HashSet<UpcomingEvent>();
            UpcomingTests = new HashSet<UpcomingTest>();
        }

        [Key,Column(Order = 0)]
        public long Id { get; set; }
        public long Number { get; set; }
        public string Character { get; set; }

        [Key, Column(Order = 1), ForeignKey("TeacherOf")]
        public long ClassTeacherId { get; set; }

        public virtual Teacher TeacherOf { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
        public virtual ICollection<Journal> Journals { get; set; }
        public virtual ICollection<UpcomingEvent> UpcomingEvents { get; set; }
        public virtual ICollection<UpcomingTest> UpcomingTests { get; set; }
    }
}
