using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Schedule : EntityBase
    {
      

        public ushort LessonNumber { get; set; }

        
        public long LessonId { get; set; }

       
        public long DayId { get; set; }


        public virtual Lesson Lesson { get; set; }
        public virtual Day Day { get; set; }

    }
}
