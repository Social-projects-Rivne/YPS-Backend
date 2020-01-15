using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class ParentToPupil
    {
        [Required]
        public long PupilId { get; set; }

        [Required]
        public long ParentId { get; set; }

        public virtual Pupil PupilOf { get; set; }
        public virtual Parent ParentOf { get; set; }
    }
}
