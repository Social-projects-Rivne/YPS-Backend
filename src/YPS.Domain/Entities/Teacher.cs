using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using YPS.Domain.Entities.Base;

namespace YPS.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public Teacher()
        {
            Materials = new HashSet<Material>();
            Classes = new HashSet<Class>();
            TeacherToDisciplines = new HashSet<TeacherToDiscipline>();
        }
        
        
        public string  Degree { get; set; }
        
       
        public long SchoolId { get; set; }
        
       
        public long UserId { get; set; }

        public virtual User /*UserOf*/User { get; set; }
        public virtual School SchoolOf { get; set; }
        public  ICollection<Class> Classes { get; set; }
        public  ICollection<Material> Materials { get; set; }
        public  ICollection<TeacherToDiscipline> TeacherToDisciplines { get; set; }
    }
}
