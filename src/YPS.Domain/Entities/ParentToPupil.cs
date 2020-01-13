using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class ParentToPupil
    {
        [Key, Column(Order = 0), ForeignKey("PupilOf")]
        public long PupilId { get; set; }

        [Key, Column(Order = 1), ForeignKey("ParentOf")]
        public long ParentId { get; set; }

        public virtual Pupil PupilOf { get; set; }
        public virtual Parent ParentOf { get; set; }
    }
}
