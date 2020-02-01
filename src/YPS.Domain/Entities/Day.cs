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
            Schedules = new HashSet<Schedule>();
        }

        public string Name { get; set; }

        public ICollection<Schedule> Schedules { get; set; }
    }
}
