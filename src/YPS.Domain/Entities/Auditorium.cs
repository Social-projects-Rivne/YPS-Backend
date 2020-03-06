using System;
using System.Collections.Generic;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Auditorium : EntityBase
    {
        public long Number { get; set; }
        public string Name { get; set; }
        
        public long SchoolId { get; set; }
        public School School { get; set; }
        
        public ICollection<Lesson> Lessons { get; set; }
    }
}
