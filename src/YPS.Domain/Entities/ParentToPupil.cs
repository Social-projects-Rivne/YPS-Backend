using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class ParentToPupil
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("Pupil")]
        public long PupilId { get; set; }
        [ForeignKey("Parent")]
        public long ParentId { get; set; }

        public Pupil Pupil { get; set; }
        public Parent Parent { get; set; }

    }
}
