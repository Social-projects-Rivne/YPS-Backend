using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Class 
    {
        public Class()
        {
            Pupils = new HashSet<Pupil>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Number { get; set; }

        public string Character { get; set; }

        [ForeignKey("Teacher")]
        public long ClassTeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Pupil> Pupils { get; set; }

    }
}
