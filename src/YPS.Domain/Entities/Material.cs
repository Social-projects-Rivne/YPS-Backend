using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Material 
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }

        [ForeignKey("Teacher")]
        public long TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
