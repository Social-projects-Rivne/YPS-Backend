using System;
using System.Collections.Generic;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class ClassToDiscipline 
    {        
        public long ClassId { get; set; }
        public Class Class { get; set; }

        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
    }
}
