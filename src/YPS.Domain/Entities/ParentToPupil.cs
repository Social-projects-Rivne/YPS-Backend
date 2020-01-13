using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class ParentToPupil
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("PupilOf"),Column(Order = 0)]
        public long PupilId { get; set; }

        [ForeignKey("ParentOf"),Column(Order = 1)]
        public long ParentId { get; set; }

        public virtual Pupil PupilOf { get; set; }
        public virtual Parent ParentOf { get; set; }
    }
}
