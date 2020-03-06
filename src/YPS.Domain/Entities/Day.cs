using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Day : EntityBase
    {
        public Day()
        {
            Lessons = new HashSet<Lesson>();
        }

        public string Name { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
