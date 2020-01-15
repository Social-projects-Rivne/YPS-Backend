using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class ParentToPupil : EntityBase
    {
       
        public long PupilId { get; set; }

        
        public long ParentId { get; set; }

        public virtual Pupil PupilOf { get; set; }
        public virtual Parent ParentOf { get; set; }
    }
}
