using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YPS.Domain.Entities
{
    public class Teacher 
    {
        public Teacher()
        {
            Materials = new HashSet<Material>();
        }
        [Key, ForeignKey("User")]
        public long Id { get; set; }
        
        public string  Degree { get; set; }
        
        [ForeignKey("SchoolOf")]
        public long SchoolId { get; set; }
        
        //[ForeignKey("UserOf")]
        //public long UserId { get; set; }

        public virtual User /*UserOf*/User { get; set; }
        public virtual School SchoolOf { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
    }
}
